using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProyectoIntegradorClinica.DataAccess.Entities;

namespace ProyectoIntegradorClinica.DataAccess.Entities
{
    [Table("CDP")]
    public class CDPEntity
    {
        [Key]
        public int IdCDP { get; set; }
        public virtual CitaEntity Cita { get; set; }
        public double PrecioCita { get; set; }
        public string EstadoCDP { get; set; }
        public string NroTarjeta { get; set; }
        public string TipoCDP { get; set; } // Boleta / Factura
        public string? NroFactura { get; set; } //Puede ser nulo

    }
}
