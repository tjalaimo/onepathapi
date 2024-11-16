using onepathapi.Models;

namespace onepathapi.DTOs
{
    public class BaseMedicationDTO
    {
        public int MedicationId { get; set; }
        public string? MedicationCode { get; set; }
        public string? MedicationName { get; set; }
        public string? Dosage { get; set; }
        public string? Frequency { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public BaseMedicationDTO() {}

        public BaseMedicationDTO(Medication medication)
        {
            MedicationId = medication.MedicationId;
            MedicationCode = medication.MedicationCode;
            MedicationName = medication.MedicationName;
            Dosage = medication.Dosage;
            Frequency = medication.Frequency;
            StartDate = medication.StartDate;
            EndDate = medication.EndDate;
        }
    }
}