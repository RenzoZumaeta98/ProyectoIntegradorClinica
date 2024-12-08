using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIntegradorClinica.DataAccess.Entities
{
    [Table("Especialidad")]
    public class EspecialidadEntity
    {
        [Key]
        public int IdEspecialidad { get; set; }
        public string NombreEspecialidad { get; set; }
        public string DescripcionEspecialidad { get; set; }
        public double PrecioConsultaEspecialidad { get; set; }

    }
}
