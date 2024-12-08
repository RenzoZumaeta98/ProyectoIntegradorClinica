using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIntegradorClinica.DataAccess.Entities
{
    [Table("Usuario")]
    public class UsuarioEntity
    {
        [Key]
        public int IdUsuario {  get; set; }
        public string NombreUsuario { get; set; }
        public string ApellidoUsuario { get; set; }
        public string CorreoUsuario { get; set; }
        public string ClaveUsuario { get; set; }
        public DateTime FechaNacUsuario { get; set; }
        public virtual DocumentoEntity Documento { get; set; }
        public string NroDocumentoUsuario { get; set; }
        public string CelularUsuario { get; set; }
        public string GeneroUsuario { get; set; }
        public string DireccionUsuario { get; set; }
        public virtual TipoUsuarioEntity TipoUsuario { get; set;}


    }
}
