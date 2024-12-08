using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIntegradorClinica.DataAccess.Entities
{
    [Table("MotivoCitaCancelada")]
    public class MotivoCitaCanceladaEntity
    {
        [Key]
        public int IdMotivoCancelado { get; set; }
        public string NombreMotivoCancelado { get; set; }
    }
}
