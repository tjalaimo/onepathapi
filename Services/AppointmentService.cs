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
        Task<BaseAppointmentDTO> CreateAppointment(AppointmentDTO newAppointment);
        Task<BaseAppointmentDTO> UpdateAppointment(AppointmentDTO updatedAppointment);
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
                    .ThenInclude(p => p.Medications)
                .Include(a => a.Patient)
                    .ThenInclude(p => p.Conditions)
                .Include(a => a.Patient)
                    .ThenInclude(p => p.User)
                .Include(a => a.Provider)
                    .ThenInclude(p => p.User)
                .Where(a => a.AppointmentId == appointmentID)
                .FirstAsync();

            return new AppointmentDTO(appointment);
        }


        public async Task<IEnumerable<AppointmentDTO>> GetProviderAppointments(int providerId)
        {
            IEnumerable<AppointmentDTO> appointments = await _context.Appointments
                .Include(a => a.Patient)
                    .ThenInclude(p => p.Medications)
                .Include(a => a.Patient)
                    .ThenInclude(p => p.Conditions)
                .Include(a => a.Patient)
                    .ThenInclude(p => p.User)
                .Include(a => a.Provider)
                    .ThenInclude(p => p.User)
                .Where(a => a.ProviderId == providerId)
                .Select(a => new AppointmentDTO(a))
                .ToListAsync();

            return appointments;
        }

        public async Task<IEnumerable<AppointmentDTO>> GetPatientAppointments(int patientId)
        {
            IEnumerable<AppointmentDTO> appointments = await _context.Appointments
                .Include(a => a.Patient)
                    .ThenInclude(p => p.Medications)
                .Include(a => a.Patient)
                    .ThenInclude(p => p.Conditions)
                .Include(a => a.Patient)
                    .ThenInclude(p => p.User)
                .Include(a => a.Provider)
                    .ThenInclude(p => p.User)
                .Where(a => a.PatientId == patientId)
                .Select(a => new AppointmentDTO(a))
                .ToListAsync();

            return appointments;
        }

        public async Task<BaseAppointmentDTO> CreateAppointment(AppointmentDTO newAppointment)
        {
            // Map DTO to the Appointment entity
            var appointment = new Appointment
            {
                PatientId = newAppointment.Patient?.PatientId,
                ProviderId = newAppointment.Provider?.ProviderId,
                AppointmentDate = newAppointment.AppointmentDate,
                Reason = newAppointment.Reason,
                Diagnosis = newAppointment.Diagnosis,
                Status = newAppointment.Status,
                Notes = newAppointment.Notes
            };

            // Add the appointment to the database
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            // Return the newly created appointment
            return new BaseAppointmentDTO(appointment);
        }

        public async Task<BaseAppointmentDTO> UpdateAppointment(AppointmentDTO updatedAppointment)
        {
            // Fetch the existing appointment            
            Appointment appointment = await _context.Appointments
                .Include(a => a.Patient)
                    .ThenInclude(p => p.Medications)
                .Include(a => a.Patient)
                    .ThenInclude(p => p.Conditions)
                .Include(a => a.Patient)
                    .ThenInclude(p => p.User)
                .Include(a => a.Provider)
                    .ThenInclude(p => p.User)
                .Where(a => a.AppointmentId == updatedAppointment.AppointmentId)
                .FirstAsync();

            if (appointment == null)
            {
                throw new KeyNotFoundException("Appointment not found.");
            }

            // Update the fields
            appointment.AppointmentDate = updatedAppointment.AppointmentDate ?? appointment.AppointmentDate;
            appointment.Reason = updatedAppointment.Reason ?? appointment.Reason;
            appointment.Diagnosis = updatedAppointment.Diagnosis ?? appointment.Diagnosis;
            appointment.Status = updatedAppointment.Status ?? appointment.Status;
            appointment.Notes = updatedAppointment.Notes ?? appointment.Notes;

            // Save changes
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();

            // Return the updated appointment
            return new BaseAppointmentDTO(appointment);
        }
    }
}
