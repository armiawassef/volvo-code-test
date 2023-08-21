using System.Linq.Expressions;

namespace CongestionTaxCalculator.Common.Repositories;

public interface IGenericRepository<TEntity> where TEntity : class
{
    IEnumerable<TEntity> GetAll();
}
