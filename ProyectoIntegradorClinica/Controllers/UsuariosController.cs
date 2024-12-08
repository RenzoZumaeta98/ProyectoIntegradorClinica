using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProyectoIntegradorClinica.Models;
using ProyectoIntegradorClinica.Servicios;
using SolAngeSolClinicaHealthla_sHealth.DataAccess;


namespace ProyectoIntegradorClinica.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly AngelasHealthContext _context;
        private readonly IRepositorioUsuarios _usuarios;

        public UsuariosController(AngelasHealthContext context, IRepositorioUsuarios usuarios)
        {
            _context = context;
            _usuarios = usuarios;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registro(UsuarioViewModel modelo) 
        {
            if (!ModelState.IsValid) 
            { 
                return RedirectToAction("Index", "Home", modelo);
            }

            _usuarios.CrearUsuario(modelo);

            return RedirectToAction("Index", "Home");
        
        }
    }
}
