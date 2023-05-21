using Lab5_6.Entities;

namespace Lab5_6.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetAllAsync();
        Task<Patient> GetByIdAsync(Guid? id);
        Task<Patient> AddAsync(Patient entity);
        Task UpdateAsync(Patient patient);
        Task DeleteAsync(Guid Id);
        IEnumerable<Patient> sortingSelection(IEnumerable<Patient> Patients, string sortOrder);
        IEnumerable<Patient> searchSelection(IEnumerable<Patient> Patients, string searchString);
        List<string> getFieldNames();
    }
}