using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorClinica.Models;
using ProyectoIntegradorClinica.Servicios;
using SolAngeSolClinicaHealthla_sHealth.DataAccess;

namespace ProyectoIntegradorClinica.Controllers
{
    public class LoginController : Controller
    {
        private readonly IRepositorioUsuarios _context;
        private readonly IMapper _mapper;

        public LoginController(IRepositorioUsuarios context, IMapper mapper) { 
            _context = context;
            _mapper = mapper;
        }

        public IActionResult PaginaUsuario(UsuarioViewModel usuarioViewModel)
        {
            var usuarioInView = _context.ValidarUsuario(usuarioViewModel);
            return View(usuarioInView);
        }
    }
}
