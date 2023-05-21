using Lab5_6.Data;
using Lab5_6.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Lab5_6.Repository.Impl;
public class PatientRepository<TEntity> : IPatientRepository<TEntity> where TEntity : Patient
{
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<TEntity> DbSet;

    public PatientRepository(ApplicationDbContext context)
    {
        _context = context;
        DbSet = context.Set<TEntity>();
    }

    public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression)
    {
        return DbSet.Where(expression).AsNoTracking();
    }

    public async Task<IList<Patient>> GetAllAsync()
    {
        return await _context.Patients.ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(Guid? id)
    {
        return await FindByCondition(product => product.Id.Equals(id)).FirstOrDefaultAsync();
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));
        entity.Id = Guid.NewGuid();

        var addedEntity = (await DbSet.AddAsync(entity)).Entity;
        await _context.SaveChangesAsync();
        return addedEntity;
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _context.Attach(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();

    }

    public async Task DeleteAsync(Guid id)
    {
        var patient = new Patient() { Id = id };
        _context.Patients.Remove(patient);
        await _context.SaveChangesAsync();
    }
}

