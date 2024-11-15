using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        // Navigation properties to link with Patient and Provider (assuming Patient and Provider classes are defined elsewhere)

        [NotMapped]
        public virtual Patient Patient { get; set; }
        [NotMapped]
        public virtual Provider Provider { get; set; }
    }
}
