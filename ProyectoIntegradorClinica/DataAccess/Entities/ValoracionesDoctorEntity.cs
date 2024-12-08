using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIntegradorClinica.DataAccess.Entities
{
    [Table("ValoracionesDoctor")]
    public class ValoracionesDoctorEntity
    {
        [Key]
        public int IdValoracion {  get; set; }
        public virtual DoctorEntity Doctor { get; set; }
        public virtual UsuarioEntity Usuario { get; set; }
        public string ComentarioValoracion { get; set; }
        public int NivelValoracion { get; set; }
        public string TipoValoracion { get; set; } //Publica / Anonima
    }
}
