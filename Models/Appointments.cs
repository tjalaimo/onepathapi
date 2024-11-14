namespace onepathapi.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int ProviderId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Reason { get; set; }
        public string Diagnosis { get; set; }
        public string Status { get; set; }

        // Navigation properties to link with Patient and Provider (assuming Patient and Provider classes are defined elsewhere)
        public virtual Patient Patient { get; set; }
        public virtual Provider Provider { get; set; }
    }
}
