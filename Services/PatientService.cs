using onepathapi.Data;
using onepathapi.Models;
using onepathapi.DTOs;
using Microsoft.EntityFrameworkCore;

namespace onepathapi.Services
{
    public interface IPatientService
    {
        Task<BasePatientDTO> GetPatient(int patientId);
        Task<BasePatientDTO> GetPatientByUserId(int userId);
        Task<(List<BasePatientDTO>, int)> GetPatients(PaginationRequest request);
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

        public async Task<BasePatientDTO> GetPatient(int patientId)
        {
            Patient patient = await _context.Patients
                .Include(p => p.User)
                .Include(p => p.Medications)
                .Include(p => p.Conditions)
                .Include(p => p.Appointments)
                    .ThenInclude(a => a.Provider)
                    .ThenInclude(p => p.User)
                .Where(p => p.PatientId == patientId)
                .FirstAsync();
            return new BasePatientDTO(patient);
        }

        public async Task<BasePatientDTO> GetPatientByUserId(int userId)
        {
            Patient patient = await _context.Patients
                .Include(p => p.User)
                .Include(p => p.Medications)
                .Include(p => p.Conditions)
                .Include(p => p.Appointments)
                    .ThenInclude(a => a.Provider)
                    .ThenInclude(p => p.User)
                .Where(p => p.User.UserId == userId)
                .FirstAsync();
            return new BasePatientDTO(patient);
        }

        public async Task<(List<BasePatientDTO>, int)> GetPatients(PaginationRequest request)
        {            
            var query = _context.Patients.AsQueryable();

            // If searchTerm is provided, apply the filters
            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                query = query.Where(p => 
                    p.FirstName.Contains(request.SearchTerm) ||
                    p.LastName.Contains(request.SearchTerm) ||
                    p.DateOfBirth.ToString().Contains(request.SearchTerm) ||
                    p.Email.Contains(request.SearchTerm) ||
                    p.Phone.Contains(request.SearchTerm) ||
                    p.Address.Contains(request.SearchTerm) ||
                    p.Conditions.Any(c => c.ConditionDescription.Contains(request.SearchTerm)) ||
                    p.Medications.Any(m => m.MedicationName.Contains(request.SearchTerm))
                );
            }

            // Apply pagination
            var totalPatients = await query.CountAsync();
            var patients = await query
                .Include(p => p.User)
                .Include(p => p.Medications)
                .Include(p => p.Conditions)
                .Include(p => p.Appointments)
                    .ThenInclude(a => a.Provider)
                    .ThenInclude(p => p.User)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            return (patients.Select(p => new BasePatientDTO(p)).ToList(), totalPatients);
        }

        public async Task<Patient> CreatePatient(Patient newPatient)
        {
            _context.Patients.Add(newPatient);
            newPatient.PatientId = await _context.SaveChangesAsync();
            return newPatient;
        }

        public async Task<Patient> UpdatePatient(Patient patient)
        {
            var _patient = await _context.Patients.Where(p => p.PatientId == patient.PatientId).FirstAsync();
            if (_patient == null) throw new ArgumentException("Patient not found");

            _context.Entry(_patient).CurrentValues.SetValues(patient);
            await _context.SaveChangesAsync();

            return patient;
        }
    }
}
