using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIntegradorClinica.DataAccess.Entities
{
    [Table("HorarioTrabajoDoctor")]
    public class HorarioTrabajoDoctorEntity
    {
        [Key]
        public int IdHorarioTrabajoDoctor {  get; set; }
        public virtual HorarioTrabajoEntity HorarioTrabajo { get; set; }
        public virtual DoctorEntity Doctor { get; set; }
    }
}
