using ProyectoIntegradorClinica.DataAccess.Entities;

namespace ProyectoIntegradorClinica.Models
{
    public class CitaViewModel
    {
        public int IdCita { get; set; }
        public string idUsuario { get; set; }
        public string idEspecialidad { get; set; }
        public string idDoctor { get; set; }
        public string FechaCita { get; set; }
        public string HoraCita { get; set; }
        public string EstadoCita { get; set; } //(Reservada, Postergada, Cancelada, Completada)
        public List<EspecialidadEntity> Especialidades { get; set; }
        public List<UsuarioEntity> Usuarios { get; set; }
        public List<DoctorEntity> Doctores { get; set; }



        public CitaViewModel()
        {
            Especialidades = new List<EspecialidadEntity>();
            Usuarios = new List<UsuarioEntity>();
            Doctores = new List<DoctorEntity>();

        }
    }
}
