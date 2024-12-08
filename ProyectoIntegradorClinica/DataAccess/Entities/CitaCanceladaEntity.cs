using ProyectoIntegradorClinica.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIntegradorClinica.DataAccess.Entities
{
    [Table("CitaCancelada")]
    public class CitaCanceladaEntity
    {
        [Key]
        public int IdCitaCancelada { get; set; }
        public virtual CitaEntity Cita { get; set; }
        public virtual MotivoCitaCanceladaEntity MotivoCitaCanceladaEntity { get; set; }
    }
}
