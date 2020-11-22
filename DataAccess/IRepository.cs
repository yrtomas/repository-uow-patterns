using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<ICollection<TEntity>> GetAllAsync();

        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        
        Task<TEntity> GetByIdAsync(object id);

        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter);

        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> filter);

        Task<TEntity> CreateAsync(TEntity entity);

        void DeleteById(object id);

        void Delete(TEntity entityToDelete);

        Task<TEntity> UpdateAsyn(TEntity entity, object key);

        Task<int> CountAsync();
    }
}