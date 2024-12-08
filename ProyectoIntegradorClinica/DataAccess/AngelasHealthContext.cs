using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorClinica.DataAccess.Entities;

namespace SolAngeSolClinicaHealthla_sHealth.DataAccess
{
    public class AngelasHealthContext : DbContext
    {
        public DbSet<TipoUsuarioEntity> TipoUsuario  { get; set; }
        public DbSet<DocumentoEntity> Documento  { get; set; }
        public DbSet<EspecialidadEntity> Especialidad { get; set; }
        public DbSet<HorarioTrabajoEntity>  HorarioTrabajo { get; set; }
        public DbSet<MotivoCitaAplazadaEntity> MotivoCitaAplazada  { get; set; }
        public DbSet<MotivoCitaCanceladaEntity> MotivoCitaCancelada  { get; set; }

        public DbSet<UsuarioEntity> Usuario  { get; set; }
        public DbSet<DoctorEntity> Doctor  { get; set; }
        public DbSet<CitaEntity> Cita  { get; set; }
        public DbSet<CDPEntity> CDP { get; set; }
        public DbSet<DevolucionPagoEntity> DevolucionPago  { get; set; }
        public DbSet<CitaAplazadaEntity> CitaAplazada  { get; set; }
        public DbSet<CitaCanceladaEntity> CitaCancelada  { get; set; }

        public DbSet<HorarioTrabajoDoctorEntity> HorarioTrabajoDoctor  { get; set; }
        public DbSet<ValoracionesDoctorEntity> ValoracionesDoctor  { get; set; }

        //ContextDB

    public AngelasHealthContext(DbContextOptions<AngelasHealthContext> option) : base(option)
        {
        }
    }
}
