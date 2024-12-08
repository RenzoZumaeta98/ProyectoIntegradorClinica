using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorClinica.DataAccess.Entities;
using ProyectoIntegradorClinica.Models;
using SolAngeSolClinicaHealthla_sHealth.DataAccess;
using System.Numerics;

namespace ProyectoIntegradorClinica.Servicios
{
    public interface IRepositorioCitas
    {
        void AddCita(CitaViewModel citaViewModel);
        UsuarioViewModel AplazarCitas(int id);
        UsuarioViewModel CancelarCitas(int id);
        CitaViewModel CargarCita(UsuarioViewModel usuario);
        CitaViewModel CargarCitaAplazada(int id);
        List<CitaViewModel> CargarCitas(UsuarioViewModel usuario);
        UsuarioViewModel GuardarPago(CitaPagoViewModel citaPagoViewModel);
        CitaPagoViewModel PagoCita(int id);
    }

    public class RepositorioCitas : IRepositorioCitas
    {
        private readonly AngelasHealthContext _context;
        private readonly IMapper _mapper;

        public RepositorioCitas(AngelasHealthContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public CitaViewModel CargarCita(UsuarioViewModel usuario)
        {
            var model = new CitaViewModel();
            model.idUsuario = usuario.IdUsuario.ToString();
            model.Especialidades = _context.Especialidad.ToList();
            model.Doctores = _context.Doctor.ToList();
            return model;
        }

        public void AddCita(CitaViewModel citaViewModel)
        {
            var reservaCita = _context.Cita.Add(new CitaEntity()
            {
                Usuario = _context.Usuario.Where(c => c.IdUsuario.ToString() == citaViewModel.idUsuario.ToString()).SingleOrDefault(),
                Doctor = _context.Doctor.Where(c => c.IdDoctor.ToString() == citaViewModel.idDoctor.ToString()).SingleOrDefault(),
                FechaCita = DateTime.Parse(citaViewModel.FechaCita),
                HoraCita = citaViewModel.HoraCita,
                EstadoCita = "Reservada"
            });

            _context.SaveChanges();
        }

        public List<CitaViewModel> CargarCitas(UsuarioViewModel usuario)
        {
            // Obtener las citas relacionadas al usuario y cargar las relaciones necesarias (Doctor y Especialidad)
            var citasListDB = _context.Cita
                .Where(c => c.Usuario.IdUsuario == usuario.IdUsuario)
                .Select(c => new
                {
                    c.IdCita,
                    c.FechaCita,
                    c.HoraCita,
                    c.EstadoCita,
                    DoctorNombreCompleto = c.Doctor.NombreDoctor + " " + c.Doctor.ApellidoDoctor,
                    EspecialidadNombre = c.Doctor.Especialidad.NombreEspecialidad
                })
                .ToList();

            // Mapear los resultados a la lista de ViewModel
            var list = citasListDB.Select(cita => new CitaViewModel
            {
                IdCita = cita.IdCita,
                idUsuario = usuario.IdUsuario.ToString(),
                FechaCita = cita.FechaCita.ToString("yyyy-MM-dd"), // Formato opcional
                HoraCita = cita.HoraCita,
                EstadoCita = cita.EstadoCita,
                idDoctor = cita.DoctorNombreCompleto,
                idEspecialidad = cita.EspecialidadNombre
            }).ToList();

            return list;
        }

        public CitaPagoViewModel PagoCita(int id)
        {
            // Buscar los datos relacionados a la cita, incluyendo doctor, especialidad y usuario
            var datos = (from cita in _context.Cita
                         join doctor in _context.Doctor on cita.Doctor.IdDoctor equals doctor.IdDoctor
                         join usuario in _context.Usuario on cita.Usuario.IdUsuario equals usuario.IdUsuario
                         join especialidad in _context.Especialidad on doctor.Especialidad.IdEspecialidad equals especialidad.IdEspecialidad
                         where cita.IdCita == id
                         select new
                         {
                             precioCita = especialidad.PrecioConsultaEspecialidad,
                             estadoCita = cita.EstadoCita,
                             paciente = usuario.NombreUsuario + " " + usuario.ApellidoUsuario,
                             documentoPaciente = usuario.NroDocumentoUsuario,
                             especialidadNombre = especialidad.NombreEspecialidad,
                             fecha = cita.FechaCita,
                             hora = cita.HoraCita,
                             costo = especialidad.PrecioConsultaEspecialidad.ToString("F2") // Formato con dos decimales
                         }).FirstOrDefault();

            if (datos == null)
            {
                return null; // Manejar caso donde no se encuentra la cita
            }

            // Mapear los datos al modelo CitaPagoViewModel
            var citaPagoModel = new CitaPagoViewModel
            {
                PrecioCita = datos.precioCita,
                EstadoCDP = "Pendiente", // Valor predeterminado, ajusta según la lógica de negocio
                NroTarjeta = null, // Inicialmente nulo, ajusta según los datos disponibles
                TipoCDP = "Boleta", // Valor predeterminado, ajusta según la lógica de negocio
                NroFactura = null, // Inicialmente nulo, ajusta según los datos disponibles
                IdCita = id.ToString(),
                EstadoCita = datos.estadoCita,
                Paciente = datos.paciente,
                DocumentoPaciente = datos.documentoPaciente,
                Especialidad = datos.especialidadNombre,
                Fecha = datos.fecha.ToString("yyyy-MM-dd"),
                Hora = datos.hora,
                Costo = datos.costo
            };

            return citaPagoModel;
        }

        public UsuarioViewModel GuardarPago(CitaPagoViewModel citaPagoViewModel)
        {
            var CDP = _context.CDP.Add(new CDPEntity()
            {
                Cita = _context.Cita.Where(c => c.IdCita.ToString() == citaPagoViewModel.IdCita.ToString()).SingleOrDefault(),
                PrecioCita = (Double)citaPagoViewModel.PrecioCita,
                EstadoCDP = citaPagoViewModel.EstadoCDP,
                NroTarjeta = citaPagoViewModel.NroTarjeta,
                TipoCDP = citaPagoViewModel.TipoCDP,
                NroFactura = citaPagoViewModel.NroFactura
            });

            var CITA = _context.Cita.FirstOrDefault(c => c.IdCita.ToString() == citaPagoViewModel.IdCita.ToString());
            CITA.EstadoCita = "Pagado";

            var idUser = (from cita in _context.Cita
                          join user in _context.Usuario
                          on cita.Usuario.IdUsuario equals user.IdUsuario
                          where cita.IdCita.ToString() == citaPagoViewModel.IdCita.ToString()
                          select user.IdUsuario).FirstOrDefault();

            var model = _context.Usuario.Where(c => c.IdUsuario.ToString() == idUser.ToString()).SingleOrDefault();
            var usuarioInView = _mapper.Map<UsuarioViewModel>(model);

            _context.SaveChanges();

            return usuarioInView;
        }


        public CitaViewModel CargarCitaAplazada(int id)
        {
            var cita = _context.Cita.Where(c => c.IdCita.ToString() == id.ToString()).ToList();
            var citaPagoModel = new CitaViewModel();

            var datos = (from citaN in _context.Cita
                         join doctorN in _context.Doctor on citaN.Doctor.IdDoctor equals doctorN.IdDoctor
                         join userN in _context.Usuario on citaN.Usuario.IdUsuario equals userN.IdUsuario
                         join especialidad in _context.Especialidad on doctorN.Especialidad.IdEspecialidad equals especialidad.IdEspecialidad
                         where citaN.IdCita.ToString() == id.ToString()
                         select new
                         {
                             nombrePaciente = userN.NombreUsuario + " " + userN.ApellidoUsuario,
                             nombreDoctor = doctorN.NombreDoctor + " " + doctorN.ApellidoDoctor,
                             documentoPaciente = userN.NroDocumentoUsuario,
                             especialidad = doctorN.Especialidad.NombreEspecialidad,
                             fecha = citaN.FechaCita.ToString(),
                             hora = citaN.HoraCita.ToString(),
                             costo = doctorN.Especialidad.PrecioConsultaEspecialidad.ToString()
                         }
                          ).FirstOrDefault();


            citaPagoModel.IdCita = id;
            citaPagoModel.idDoctor = datos.nombreDoctor;
            citaPagoModel.idEspecialidad = datos.especialidad;
            citaPagoModel.FechaCita = datos.fecha;
            citaPagoModel.HoraCita = datos.hora;

            return citaPagoModel;
        }

        public UsuarioViewModel AplazarCitas(int id)
        {
            // Cargar la cita con su usuario relacionado
            var cita = _context.Cita
                .Include(c => c.Usuario) // Incluye el usuario relacionado
                .FirstOrDefault(c => c.IdCita == id);

            // Actualizar estado de la cita
            cita.EstadoCita = "Aplazada";
            _context.SaveChanges();

            // Mapear el usuario relacionado a UsuarioViewModel
            var usuarioInView = new UsuarioViewModel
            {
                IdUsuario = cita.Usuario.IdUsuario,
                NombreUsuario = cita.Usuario.NombreUsuario,
                ApellidoUsuario = cita.Usuario.ApellidoUsuario,
                CorreoUsuario = cita.Usuario.CorreoUsuario,
                ClaveUsuario = cita.Usuario.ClaveUsuario,
                FechaNacUsuario = cita.Usuario.FechaNacUsuario.ToString("yyyy-MM-dd"),
                TipoDocumento = cita.Usuario.Documento?.NombreDocumento ?? "Sin documento",
                NroDocumentoUsuario = cita.Usuario.NroDocumentoUsuario,
                CelularUsuario = cita.Usuario.CelularUsuario,
                GeneroUsuario = cita.Usuario.GeneroUsuario,
                DireccionUsuario = cita.Usuario.DireccionUsuario,
                TipoUsuario = cita.Usuario.TipoUsuario?.NombreTipoUsuario ?? "Desconocido"
            };

            return usuarioInView;
        }

        public UsuarioViewModel CancelarCitas(int id)
        {
            // Cargar la cita con su usuario relacionado
            var cita = _context.Cita
                .Include(c => c.Usuario) // Incluye el usuario relacionado
                .FirstOrDefault(c => c.IdCita == id);

            // Actualizar estado de la cita
            cita.EstadoCita = "Cancelada";
            _context.SaveChanges();

            // Mapear el usuario relacionado a UsuarioViewModel
            var usuarioInView = new UsuarioViewModel
            {
                IdUsuario = cita.Usuario.IdUsuario,
                NombreUsuario = cita.Usuario.NombreUsuario,
                ApellidoUsuario = cita.Usuario.ApellidoUsuario,
                CorreoUsuario = cita.Usuario.CorreoUsuario,
                ClaveUsuario = cita.Usuario.ClaveUsuario,
                FechaNacUsuario = cita.Usuario.FechaNacUsuario.ToString("yyyy-MM-dd"),
                TipoDocumento = cita.Usuario.Documento?.NombreDocumento ?? "Sin documento",
                NroDocumentoUsuario = cita.Usuario.NroDocumentoUsuario,
                CelularUsuario = cita.Usuario.CelularUsuario,
                GeneroUsuario = cita.Usuario.GeneroUsuario,
                DireccionUsuario = cita.Usuario.DireccionUsuario,
                TipoUsuario = cita.Usuario.TipoUsuario?.NombreTipoUsuario ?? "Desconocido"
            };

            return usuarioInView;
        }

    }
}
