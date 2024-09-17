using MongoDB.Bson;
using System.Linq.Expressions;

namespace Villa.DataAccess.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(ObjectId id);
        Task<List<T>> GetListAsync();
        Task<T> GetByIdAsync(ObjectId id);
        Task<int> GetCountAsync();
        Task<List<T>> GetFilteredListAsync(Expression<Func<T, bool>> predicate);
    }
}
