using Lab4.API.DbContexts;
using Lab4.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lab4.API.Services
{
    public class PatientInfoRepository : IPatientInfoRepository
    {
        private readonly PatientInfoContext _context;

        public PatientInfoRepository(PatientInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Diagnosis?> GetDiagnosisAsync(int diagnosisId)
        {
            return await _context.Diagnoses.FirstOrDefaultAsync(diagnosis => diagnosis.Id == diagnosisId);
        }

        public async Task<IEnumerable<Diagnosis>> GetDiagnosesListAsync()
        {
            return await _context.Diagnoses.OrderBy(diagnosis => diagnosis.Id).ToListAsync();
        }

        public async Task<Patient?> GetPatientAsync(int patientId)
        {
            return await _context.Patients.FirstOrDefaultAsync(patient => patient.Id == patientId);
        }

        public async Task<IEnumerable<Patient>> GetPatientsAsync()
        {
            return await _context.Patients.OrderBy(patient => patient.LastName).ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public async Task<bool> PatientExistsAsync(int patientId)
        {
            return await _context.Patients.AnyAsync(patient => patient.Id == patientId);
        }

        public void DeletePatient(Patient patient)
        {
            _context.Patients.Remove(patient);
        }

        public async Task AddPatientAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
        }
    }
}
