using ProyectoIntegradorClinica.Models;
using SolAngeSolClinicaHealthla_sHealth.DataAccess;
using ProyectoIntegradorClinica.DataAccess.Entities;
using AutoMapper;

namespace ProyectoIntegradorClinica.Servicios
{
    public interface IRepositorioUsuarios
    {
        int CrearUsuario(UsuarioViewModel usuarioViewModel);
        UsuarioEntity ObtenerUsuarioPorCorreo(string correoUsuario);
        UsuarioEntity ObtenerUsuarioPorId(int idUsuario);
        UsuarioViewModel ValidarUsuario(UsuarioViewModel usuarioViewModel);
    }
    public class RepositorioUsuarios: IRepositorioUsuarios
    {
        private readonly AngelasHealthContext _context;
        private readonly IMapper _mapper;

        public RepositorioUsuarios(AngelasHealthContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int CrearUsuario(UsuarioViewModel usuarioViewModel)
        {
            var usuarioRegistro = new UsuarioEntity
            {
                NombreUsuario = usuarioViewModel.NombreUsuario,
                ApellidoUsuario = usuarioViewModel.ApellidoUsuario,
                CorreoUsuario = usuarioViewModel.CorreoUsuario,
                ClaveUsuario = usuarioViewModel.ClaveUsuario,
                FechaNacUsuario = DateTime.Parse(usuarioViewModel.FechaNacUsuario),
                Documento = _context.Documento.SingleOrDefault(c => c.IdDocumento.ToString() == usuarioViewModel.TipoDocumento),
                NroDocumentoUsuario = usuarioViewModel.NroDocumentoUsuario,
                CelularUsuario = usuarioViewModel.CelularUsuario,
                GeneroUsuario = usuarioViewModel.GeneroUsuario,
                DireccionUsuario = usuarioViewModel.DireccionUsuario,
                TipoUsuario = _context.TipoUsuario.SingleOrDefault(c => c.IdTipoUsuario.ToString() == usuarioViewModel.TipoUsuario)
            };

            // Agregar el usuario al contexto
            _context.Usuario.Add(usuarioRegistro);

            // Guardar los cambios en la base de datos
            _context.SaveChanges();

            // Retornar el Id del usuario creado
            return usuarioRegistro.IdUsuario;
        }

        public UsuarioEntity ObtenerUsuarioPorId(int idUsuario)
        {
            return _context.Usuario.Where(c => c.IdUsuario == idUsuario).SingleOrDefault();
        }

        public UsuarioEntity ObtenerUsuarioPorCorreo(string correoUsuario)
        {
            return _context.Usuario.SingleOrDefault(u => u.CorreoUsuario == correoUsuario);
        }

        public UsuarioViewModel ValidarUsuario(UsuarioViewModel usuarioViewModel) {

            var usuarioIngreso = _context.Usuario.Where(c => c.CorreoUsuario == usuarioViewModel.CorreoUsuario && c.ClaveUsuario == usuarioViewModel.ClaveUsuario).Single();
            var usuarioInView = _mapper.Map<UsuarioViewModel>(usuarioIngreso);
            return usuarioInView;
        }
    }
}
