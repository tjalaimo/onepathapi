using onepathapi.Data;
using onepathapi.Models;
using onepathapi.Services;
using Microsoft.EntityFrameworkCore;

namespace onepathapi.Services
{
    public interface IAppointmentService
    {
        Task<Appointment> getAppointment(int appointmentID);
        Task<Appointment> CreateAppointment(Appointment newAppointment);
        Task<IEnumerable<Appointment>> GetUserAppointments(int patientId);
        Task<Appointment> UpdateAppointment(Appointment Appointment);
    }

    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext _context;
        private readonly IPatientService _patientsService;
        private readonly IProviderService _providerService;

        public AppointmentService(ApplicationDbContext context, IPatientService patientsService, IProviderService providerService)
        {
            _context = context;
            _patientsService = patientsService;
            _providerService = providerService;
        }

        public async Task<Appointment> getAppointment(int appointmentID)
        {
            Appointment appointment = await _context.Appointments.Where(a => a.AppointmentId == appointmentID).FirstAsync();
            if (null != appointment.PatientId)
            {
                appointment.Patient = await _patientsService.GetPatient(appointment.PatientId.Value);
            }
            if (null != appointment.ProviderId)
            {
                appointment.Provider = await _providerService.GetProvider(appointment.ProviderId.Value);
            }
            return appointment;
        }

        public async Task<Appointment> CreateAppointment(Appointment newAppointment)
        {
            _context.Appointments.Add(newAppointment);
            newAppointment.AppointmentId = await _context.SaveChangesAsync();
            return newAppointment;
        }

        public async Task<IEnumerable<Appointment>> GetUserAppointments(int patientId)
        {
            IEnumerable<Appointment> appointments = await _context.Appointments.Where(a => a.PatientId == patientId).ToListAsync();
            foreach (Appointment appointment in appointments)
            {
                if (null != appointment.PatientId)
                {
                    appointment.Patient = await _patientsService.GetPatient(appointment.PatientId.Value);
                }
                if (null != appointment.ProviderId)
                {
                    appointment.Provider = await _providerService.GetProvider(appointment.ProviderId.Value);
                }
            }
            return appointments;
        }

        public async Task<Appointment> UpdateAppointment(Appointment appointment)
        {
            var _appointment = await _context.Appointments.FindAsync(appointment);
            if (_appointment == null) throw new ArgumentException("Appointment not found");

            _appointment = appointment;
            await _context.SaveChangesAsync();

            return _appointment;
        }
    }
}
