using Lab5_6.Entities;

namespace Lab5_6.Repository
{
    public interface IPatientRepository<TEntity> where TEntity : Patient
    {
        Task<IList<Patient>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Guid? id);
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(Guid id);
    }
}
