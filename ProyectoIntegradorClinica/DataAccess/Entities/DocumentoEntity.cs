using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIntegradorClinica.DataAccess.Entities
{
    [Table("Documento")]
    public class DocumentoEntity
    {
        [Key]
        public int IdDocumento { get; set; }
        public string NombreDocumento { get; set; } //DNI, Carne Extranjeria, Pasaporte
    }
}
