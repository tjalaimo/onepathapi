using System.ComponentModel.DataAnnotations;

namespace onepathapi.Models
{
    public class Medication
    {
        [Key]
        public int MedicationId { get; set; }
        public int? PatientId { get; set; }                
        public int? AppointmentId { get; set; }
        [MaxLength(255)]
        public string? MedicationCode { get; set; }
        [MaxLength(255)]
        public string? MedicationName { get; set; }
        [MaxLength(255)]
        public string? Dosage { get; set; }
        [MaxLength(255)]
        public string? Frequency { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual Appointment Appointment { get; set; }
    }
}