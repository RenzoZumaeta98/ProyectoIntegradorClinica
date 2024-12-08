using Microsoft.AspNetCore.Mvc;
using ProyectoIntegradorClinica.Servicios;
using SolAngeSolClinicaHealthla_sHealth.DataAccess;

namespace ProyectoIntegradorClinica.Controllers
{
    public class EspecialidadController : Controller
    {
        private readonly AngelasHealthContext _context;
        private readonly IRepositorioEspecialidades _especialidades;

        public EspecialidadController(AngelasHealthContext context, IRepositorioEspecialidades especialidades)
        {
            _context = context;
            _especialidades = especialidades;
        }
        public IActionResult IndexEspecialidades()
        {
            var especialidades = _especialidades.ObtenerEspecialidades();

            return View(especialidades);
        }





    }
}
