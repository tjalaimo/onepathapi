using onepathapi.Models;

namespace onepathapi.DTOs
{
    public class BasePatientDTO
    {
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
        public BaseUserDTO User { get; set; }
        public IEnumerable<BaseAppointmentDTO>? Appointments { get; set; }
        public IEnumerable<BaseMedicationDTO>? Medications { get; set; }
        public IEnumerable<BaseConditionDTO>? Conditions { get; set; }

        public BasePatientDTO(Patient patient)
        {
            PatientId = patient.PatientId;
            Identifier = patient.Identifier;
            FirstName = patient.FirstName;
            LastName = patient.LastName;
            DateOfBirth = patient.DateOfBirth;
            Gender = patient.Gender;
            Address = patient.Address;
            Phone = patient.Phone;
            Email = patient.Email;
            Communication = patient.Communication;
            User = patient.User != null ? new BaseUserDTO(patient.User) : null;
            Appointments = patient.Appointments != null ? patient.Appointments.Select(a => new BaseAppointmentDTO(a)).ToList() : null;
            Medications = patient.Medications != null ? patient.Medications.Select(m => new BaseMedicationDTO(m)).ToList() : null;
            Conditions = patient.Conditions != null ? patient.Conditions.Select(c => new BaseConditionDTO(c)).ToList() : null;
        }
    }
}