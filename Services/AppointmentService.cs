using Microsoft.EntityFrameworkCore;
using onepathapi.Data;
using onepathapi.Models;
using onepathapi.DTOs;

namespace onepathapi.Services
{
    public interface IAppointmentService
    {
        Task<AppointmentDTO> getAppointment(int appointmentID);
        Task<IEnumerable<AppointmentDTO>> GetPatientAppointments(int patientId);
        Task<IEnumerable<AppointmentDTO>> GetProviderAppointments(int provider);
        Task<AppointmentDTO> CreateAppointment(Appointment newAppointment);
        Task<AppointmentDTO> UpdateAppointment(Appointment Appointment);
    }

    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext _context;

        public AppointmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AppointmentDTO> getAppointment(int appointmentID)
        {
            Appointment appointment = await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Provider)
                .Where(a => a.AppointmentId == appointmentID)
                .FirstAsync();

            return new AppointmentDTO(appointment);
        }


        public async Task<IEnumerable<AppointmentDTO>> GetProviderAppointments(int providerId)
        {
            IEnumerable<AppointmentDTO> appointments = await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Provider)
                .Where(a => a.ProviderId == providerId)
                .Select(a => new AppointmentDTO(a))
                .ToListAsync();

            return appointments;
        }

        public async Task<IEnumerable<AppointmentDTO>> GetPatientAppointments(int patientId)
        {
            IEnumerable<AppointmentDTO> appointments = await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Provider)
                .Where(a => a.PatientId == patientId)
                .Select(a => new AppointmentDTO(a))
                .ToListAsync();

            return appointments;
        }

        public async Task<AppointmentDTO> CreateAppointment(Appointment newAppointment)
        {
            _context.Appointments.Add(newAppointment);
            newAppointment.AppointmentId = await _context.SaveChangesAsync();
            return new AppointmentDTO(newAppointment);
        }

        public async Task<AppointmentDTO> UpdateAppointment(Appointment appointment)
        {
            var _appointment = await _context.Appointments.FindAsync(appointment);
            if (_appointment == null) throw new ArgumentException("Appointment not found");

            _appointment = appointment;
            await _context.SaveChangesAsync();

            return new AppointmentDTO(_appointment);
        }
    }
}
