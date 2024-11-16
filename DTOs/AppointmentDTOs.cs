using onepathapi.Models;

namespace onepathapi.DTOs
{
    public class BaseAppointmentDTO
    {
        public int AppointmentId { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public string? Reason { get; set; }
        public string? Diagnosis { get; set; }
        public string? Status { get; set; }
        public string? Notes { get; set; }
        public BaseProviderDTO Provider { get; set; }

        public BaseAppointmentDTO() {}

        public BaseAppointmentDTO(Appointment appointment)
        {
            AppointmentId = appointment.AppointmentId;
            AppointmentDate = appointment.AppointmentDate;
            Reason = appointment.Reason;
            Diagnosis = appointment.Diagnosis;
            Status = appointment.Status;
            Notes = appointment.Notes;
            Provider = new BaseProviderDTO(appointment.Provider);
        }
    }

    public class AppointmentDTO : BaseAppointmentDTO
    {
        public BasePatientDTO Patient { get; set; }
        public BaseProviderDTO Provider { get; set; }

        public AppointmentDTO() : base() {}

        public AppointmentDTO(Appointment appointment) : base(appointment)
        {
            Patient = new BasePatientDTO(appointment.Patient);
            Provider = new BaseProviderDTO(appointment.Provider);
        }
    }
}