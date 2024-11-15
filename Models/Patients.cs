using System.ComponentModel.DataAnnotations;

namespace onepathapi.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        public string Identifier { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? MaritalStatus { get; set; }
        public string? Communication { get; set; }
                
        public virtual User User { get; set; }
        public virtual ICollection<Appointment>? Appointments { get; set; }
        public virtual ICollection<Condition>? Conditions { get; set; }    
        public virtual ICollection<Medication>? Medications { get; set; }
    }
}
