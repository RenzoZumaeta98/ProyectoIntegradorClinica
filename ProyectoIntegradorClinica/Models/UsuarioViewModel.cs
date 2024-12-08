using ProyectoIntegradorClinica.DataAccess.Entities;
using System;

namespace ProyectoIntegradorClinica.Models
{
	public class UsuarioViewModel
	{
		public int IdUsuario { get; set; }
		public string NombreUsuario { get; set; }
		public string ApellidoUsuario { get; set; }
		public string CorreoUsuario { get; set; }
		public string ClaveUsuario { get; set; }
		public string FechaNacUsuario { get; set; }
		public string TipoDocumento { get; set; }
		public string NroDocumentoUsuario { get; set; }
		public string CelularUsuario { get; set; }
		public string GeneroUsuario { get; set; }
		public string DireccionUsuario { get; set; }
		public string TipoUsuario { get; set; }
	}
}
