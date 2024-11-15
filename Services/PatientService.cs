using onepathapi.Data;
using onepathapi.Models;
using onepathapi.DTOs;
using Microsoft.EntityFrameworkCore;

namespace onepathapi.Services
{
    public interface IPatientService
    {
        Task<Patient> GetPatient(int patientId);
        Task<IEnumerable<Patient>> GetPatients(PaginationRequest request);
        Task<Patient> CreatePatient(Patient newPatient);
        Task<Patient> UpdatePatient(Patient patient);    
    }

    public class PatientService : IPatientService
    {

        private readonly ApplicationDbContext _context;

        public PatientService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Patient> GetPatient(int patientId)
        {
            return await _context.Patients.Where(p => p.PatientId == patientId).FirstAsync();
        }

        public async Task<IEnumerable<Patient>> GetPatients(PaginationRequest request)
        {
            //TODO do search
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patient> CreatePatient(Patient newPatient)
        {
            _context.Patients.Add(newPatient);
            newPatient.PatientId = await _context.SaveChangesAsync();
            return newPatient;
        }

        public async Task<Patient> UpdatePatient(Patient patient)
        {
            var _patient = await _context.Patients.FindAsync(patient);
            if (_patient == null) throw new ArgumentException("Appointment not found");

            _patient = patient;
            await _context.SaveChangesAsync();

            return _patient;
        }
    }
}
