using DataAccess.Data;
using DataAccess.Data.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Business.Repository;

public interface IResourceRepository<T> where T : ResourceBase
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<T> CreateResource(T resource);
    Task<bool> UpdateResource(T resource);
    Task<bool> DeleteResource(int id);
}

public class ResourceRepository<TResource> : IResourceRepository<TResource> where TResource : ResourceBase
{
    protected readonly ApplicationDbContext _dbContext;

    public ResourceRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<List<TResource>> GetAllAsync()
    {
        return await _dbContext.Set<TResource>().ToListAsync();
    }

    public virtual async Task<TResource> GetByIdAsync(int id)
    {
        return await _dbContext.Set<TResource>().FindAsync(id);
    }

    public virtual async Task<TResource> CreateResource(TResource resource)
    {
        await _dbContext.Set<TResource>().AddAsync(resource);
        var result = await _dbContext.SaveChangesAsync() > 0;
        if (!result)
        {
            return null;
        }

        return resource;
    }

    public virtual async Task<bool> UpdateResource(TResource resource)
    {
        var entity = await _dbContext.Set<TResource>().FindAsync(resource.Id);

        if (entity == null)
        {
            return false;
        }
        
        _dbContext.Entry(entity).CurrentValues.SetValues(resource);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public virtual async Task<bool> DeleteResource(int id)
    {
        var entity = await _dbContext.Set<TResource>().FindAsync(id);

        if (entity == null)
        {
            return false;
        }

        _dbContext.Set<TResource>().Remove(entity);
        return await _dbContext.SaveChangesAsync() > 0;
    }

}