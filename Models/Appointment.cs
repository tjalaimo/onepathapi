using System.ComponentModel.DataAnnotations;

namespace onepathapi.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        public int? PatientId { get; set; }
        public int? ProviderId { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public string? Reason { get; set; }
        public string? Diagnosis { get; set; }
        public string? Status { get; set; }
        public string? Notes { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual Provider Provider { get; set; }
    }
}
