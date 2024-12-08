using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIntegradorClinica.DataAccess.Entities
{
    [Table("DevolucionPago")]
    public class DevolucionPagoEntity
    {
        [Key]
        public int IdDevolcuionPago { get; set; }
        public virtual CDPEntity CDP { get; set; }
        public string EstadoDevolucion { get; set; }
    }
}
