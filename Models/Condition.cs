using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace onepathapi.Models
{
    public class Condition
    {
        [Key]
        public int ConditionId { get; set; }        
        public int? PatientId { get; set; }        
        public int? AppointmentId { get; set; }
        [MaxLength(255)]
        public string? ConditionCode { get; set; }
        [MaxLength(255)]
        public string? ConditionDescription { get; set; }
        public DateTime? OnsetDate { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual Appointment Appointment { get; set; }
    }
}