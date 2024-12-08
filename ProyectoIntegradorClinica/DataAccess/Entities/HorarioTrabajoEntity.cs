using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIntegradorClinica.DataAccess.Entities
{
    [Table("HorarioTrabajo")]
    public class HorarioTrabajoEntity
    {
        [Key]
        public int IdHorarioTrabajo { get; set; }
        public DateTime FechaHorarioTrabajo { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin {  get; set; }
    }
}
