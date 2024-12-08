using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProyectoIntegradorClinica.DataAccess.Entities;
using ProyectoIntegradorClinica.Models;
using ProyectoIntegradorClinica.Servicios;

namespace ProyectoIntegradorClinica.Controllers
{
    public class CitaController : Controller
    {
        private readonly IRepositorioCitas _context;
        private readonly IRepositorioUsuarios _contextUsuario;
        private readonly IMapper _mapper;

        public CitaController(IRepositorioCitas context,IRepositorioUsuarios repositorioUusarios, IMapper mapper)
        {
            _context = context;
            _contextUsuario = repositorioUusarios;
            _mapper = mapper;
        }
        public IActionResult AgendarCita(UsuarioViewModel usuario)
        {
            var citaModel = _context.CargarCita(usuario);
            return View(citaModel);
        }

        [HttpPost]
        public IActionResult SaveReserva(CitaViewModel citaViewModel)
        {
            _context.AddCita(citaViewModel);
            return RedirectToAction("CitaReservada", new { idUser = citaViewModel.idUsuario.ToString() });
        }

        public IActionResult CitaReservada(string idUser)
        {
            int idUsuario = int.Parse(idUser);
            var model = _contextUsuario.ObtenerUsuarioPorId(idUsuario);
            var usuarioInView = _mapper.Map<UsuarioViewModel>(model);

            return View(usuarioInView);
        }

        public IActionResult ListarCitas(UsuarioViewModel usuario)
        {
            var list = _context.CargarCitas(usuario);
            return View(list);
        }

        public IActionResult PagarCita(int id)
        {
            var citaPagoViewModel = _context.PagoCita(id);

            return View(citaPagoViewModel);
        }

        [HttpPost]
        public IActionResult SavePago(CitaPagoViewModel citaPagoViewModel)
        {
            var usuarioInView = _context.GuardarPago(citaPagoViewModel);
            return RedirectToAction("ListarCitas", usuarioInView);
        }


        public IActionResult AplazarCita(int id)
        {
            var citaPagoModel = _context.CargarCitaAplazada(id);
            return View(citaPagoModel);
        }

        public IActionResult CancelarCita(int id)
        {
            var citaPagoModel = _context.CargarCitaAplazada(id);
            return View(citaPagoModel);
        }

        public IActionResult AplazarCitas(int id)
        {
            var usuarioInView = _context.AplazarCitas(id);

            return RedirectToAction("ListarCitas", usuarioInView);
        }

        public IActionResult CancelarCitas(int id)
        {
            var usuarioInView = _context.CancelarCitas(id);

            return RedirectToAction("ListarCitas", usuarioInView);
        }
    }
}
