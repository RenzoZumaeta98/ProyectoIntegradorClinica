using System.ComponentModel.DataAnnotations;

namespace ProyectoIntegradorClinica.Models
{
    public class RegistroViewModel
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(50, ErrorMessage = "El apellido no puede tener más de 50 caracteres.")]
        public string ApellidoUsuario { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "Debe ser un correo electrónico válido.")]
        public string CorreoUsuario { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "La contraseña debe tener entre 6 y 100 caracteres.")]
        [DataType(DataType.Password)]
        public string ClaveUsuario { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public string FechaNacUsuario { get; set; }

        [Required(ErrorMessage = "El tipo de documento es obligatorio.")]
        [StringLength(20, ErrorMessage = "El tipo de documento no puede tener más de 20 caracteres.")]
        public string TipoDocumento { get; set; }

        [Required(ErrorMessage = "El número de documento es obligatorio.")]
        [StringLength(15, ErrorMessage = "El número de documento no puede tener más de 15 caracteres.")]
        public string NroDocumentoUsuario { get; set; }

        [Required(ErrorMessage = "El celular es obligatorio.")]
        [Phone(ErrorMessage = "Debe ser un número de celular válido.")]
        [StringLength(15, ErrorMessage = "El número de celular no puede tener más de 15 caracteres.")]
        public string CelularUsuario { get; set; }

        [Required(ErrorMessage = "El género es obligatorio.")]
        [StringLength(10, ErrorMessage = "El género no puede tener más de 10 caracteres.")]
        public string GeneroUsuario { get; set; }

        [StringLength(200, ErrorMessage = "La dirección no puede tener más de 200 caracteres.")]
        public string DireccionUsuario { get; set; }

        [Required(ErrorMessage = "El tipo de usuario es obligatorio.")]
        [StringLength(20, ErrorMessage = "El tipo de usuario no puede tener más de 20 caracteres.")]
        public string TipoUsuario { get; set; }
    }
}
