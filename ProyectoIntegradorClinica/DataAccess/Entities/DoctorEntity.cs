using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace ProyectoIntegradorClinica.DataAccess.Entities
{
    [Table("Doctor")]
    public class DoctorEntity
    {
        [Key]
        public int IdDoctor { get; set; }
        public string NombreDoctor { get; set; }
        public string ApellidoDoctor { get; set; }
        public string CorreoDoctor { get; set; }
        public DateTime FechaNacDoctor { get; set; }
        public virtual DocumentoEntity Documento { get; set; }
        public string NroDocumentoDoctor { get; set; }
        public string CelularDoctor { get; set; }  
        public string GeneroDoctor { get; set; }
        public string DireccionDoctor { get; set; }
        public virtual EspecialidadEntity Especialidad { get; set; }
        public string DescripcionDoctor { get; set; }
        public string TitulosDoctor { get; set; }
        public string EstudiosDoctor { get; set; }


    }
}
