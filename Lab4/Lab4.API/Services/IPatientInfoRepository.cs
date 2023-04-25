using Lab4.API.Entities;
namespace Lab4.API.Services
{
    public interface IPatientInfoRepository
    {
        Task<IEnumerable<Patient>> GetPatientsAsync();

        Task<Patient?> GetPatientAsync(int patientId);

        Task<Diagnosis?> GetDiagnosisAsync(int diagnosisId);

        Task<IEnumerable<Diagnosis>> GetDiagnosesListAsync();

        Task AddPatientAsync(Patient patient);

        Task<bool> SaveChangesAsync();

        Task<bool> PatientExistsAsync(int patientId);

        void DeletePatient(Patient patient);
    }
}
