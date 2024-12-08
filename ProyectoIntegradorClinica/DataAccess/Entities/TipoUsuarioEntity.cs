using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIntegradorClinica.DataAccess.Entities
{
    [Table("TipoUsuario")]
    public class TipoUsuarioEntity
    {
        [Key]
        public int IdTipoUsuario { get; set; }
        public string NombreTipoUsuario { get; set; }
    }
}
