namespace ProyectoIntegradorClinica.Models
{
    public class CitaPagoViewModel
    {
        public double PrecioCita { get; set; }
        public string EstadoCDP { get; set; }
        public string NroTarjeta { get; set; }
        public string TipoCDP { get; set; } // Boleta / Factura
        public string NroFactura { get; set; } //Puede ser nulo



        public string IdCita { get; set; }
        public string EstadoCita { get; set; }
        public string Paciente { get; set; }
        public string DocumentoPaciente { get; set; }
        public string Especialidad { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Costo { get; set; }
    }
}
