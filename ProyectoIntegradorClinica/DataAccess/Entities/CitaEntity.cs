using ProyectoIntegradorClinica.DataAccess.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIntegradorClinica.DataAccess.Entities
{
    [Table("Cita")]
    public class CitaEntity
    {
        [Key]
        public int IdCita { get; set; }
        public virtual UsuarioEntity Usuario { get; set; }
        public virtual DoctorEntity Doctor { get; set; }
        public DateTime FechaCita { get; set; }
        public string HoraCita { get; set; }
        public string EstadoCita { get; set; } //(Reservada, Postergada, Cancelada, Completada)
    }
}
