using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using CongestionTaxCalculator.Common.Repositories;
using CongestionTaxCalculator.Infrastructure.DbContexts;

namespace CongestionTaxCalculator.Infrastructure.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    protected readonly ApplicationDbContext Context;

    public GenericRepository(ApplicationDbContext context)
    {
        Context = context;
    }

    public TEntity? Get(object id)
    {
        return Context.Set<TEntity>().Find(id);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return Context.Set<TEntity>().ToList();
    }

    public IQueryable<TEntity> AsQueryable()
    {
        return Context.Set<TEntity>().AsQueryable();
    }

    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return Context.Set<TEntity>().Where(predicate);
    }

    public TEntity? SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
    {
        return Context.Set<TEntity>().SingleOrDefault(predicate);
    }

    public bool Any(Expression<Func<TEntity, bool>> predicate)
    {
        return Context.Set<TEntity>().Any(predicate);
    }

    public TEntity Add(TEntity entity)
    {
        var result = Context.Set<TEntity>().Add(entity);
        return result.Entity;
    }

    public void AddRange(IEnumerable<TEntity> entities)
    {
        Context.Set<TEntity>().AddRange(entities);
    }

    public TEntity Update(TEntity entity)
    {
        var result = Context.Set<TEntity>().Update(entity);
        return result.Entity;
    }

    public void Remove(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        Context.Set<TEntity>()
            .RemoveRange(entities);
    }

    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        Context.Set<TEntity>()
            .UpdateRange(entities);
    }
    public async Task<TEntity?> GetAsync(object id)
    {
        return await Context.Set<TEntity>().FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await Context.Set<TEntity>().ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await Task.Run(() => Find(predicate));
    }

    public async Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await Context.Set<TEntity>().SingleOrDefaultAsync(predicate);
    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await Context.Set<TEntity>().AnyAsync(predicate);
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        var result = await Context.Set<TEntity>().AddAsync(entity);
        return result.Entity;
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await Context.Set<TEntity>().AddRangeAsync(entities);
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        return await Task.Run(() => Update(entity));
    }
    public async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
    {
        await Task.Run(() => UpdateRange(entities));
    }

    public async Task RemoveAsync(TEntity entity)
    {
        await Task.Run(() => Remove(entity));
    }

    public async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
    {
        await Task.Run(() => RemoveRange(entities));
    }

    public virtual async Task<IQueryable<TEntity>> GetAllAsync(
    Expression<Func<TEntity, bool>> filter = null,
    int pageNumber = 0,
    int itemsPerPage = 0,
    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
    string includeProperties = null)
    {
        IQueryable<TEntity> query = Context.Set<TEntity>();

        if (!string.IsNullOrEmpty(includeProperties) && !string.IsNullOrWhiteSpace(includeProperties))
        {
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (!string.IsNullOrEmpty(includeProperty))
                {
                    query = query.Include(includeProperty);
                }
            }
        }
        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (orderBy != null)
        {
            if (pageNumber > 0 && itemsPerPage > 0)
            {
                query = orderBy(query)
                    .Skip((pageNumber - 1) * itemsPerPage)
                    .Take(itemsPerPage);
            }
            else
            {
                query = orderBy(query); ;
            }
        }
        else
        {
            if (pageNumber > 0 && itemsPerPage > 0)
            {
                query = query
                    .Skip((pageNumber - 1) * itemsPerPage)
                    .Take(itemsPerPage);
            }
        }
        return await Task.FromResult(query);
    }
}