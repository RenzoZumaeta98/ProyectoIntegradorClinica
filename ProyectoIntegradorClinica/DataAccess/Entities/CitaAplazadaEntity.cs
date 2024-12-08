using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProyectoIntegradorClinica.DataAccess.Entities;

namespace ProyectoIntegradorClinica.DataAccess.Entities
{
    [Table("CitaAplazada")]
    public class CitaAplazadaEntity
    {
        [Key]
        public int IdCitaAplazada { get; set; }
        public virtual CitaEntity Cita { get; set; }
        public virtual MotivoCitaAplazadaEntity Motivo { get; set; }


    }
}
