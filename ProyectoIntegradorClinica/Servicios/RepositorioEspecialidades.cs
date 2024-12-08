using SolAngeSolClinicaHealthla_sHealth.DataAccess;
using ProyectoIntegradorClinica.DataAccess.Entities;

namespace ProyectoIntegradorClinica.Servicios
{
    public interface IRepositorioEspecialidades {
        List<EspecialidadEntity> ObtenerEspecialidades();
    }
    public class RepositorioEspecialidades: IRepositorioEspecialidades
    {
        private readonly AngelasHealthContext _context;

        public RepositorioEspecialidades(AngelasHealthContext context)
        {
            _context = context;
        }

        public List<EspecialidadEntity> ObtenerEspecialidades()
        {
            return _context.Especialidad.ToList();
        }
    }
}
