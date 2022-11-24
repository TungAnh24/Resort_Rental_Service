using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Resort_Rental.Repository.RepositoryBase
{
    public interface IBaseRepository<T, Key> where T : class
    {
        Task InsertAsnyc(T entity);
        Task InsertAll(IEnumerable<T> entities);
        Task UpdateAsnyc(T entity);
        Task UpdateAll(IEnumerable<T> entities);
        Task DeleteAsnyc(T entity);
        Task DeleteAll(IEnumerable<T> entities);
        Task<T?> FindById(Key id);
        Task<IEnumerable<T>> GetAll();
        Task<bool> IsExist(Expression<Func<T, bool>> predicate);
    }
}
