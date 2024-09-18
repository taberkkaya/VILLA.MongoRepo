using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using System.Linq.Expressions;
using Villa.DataAccess.Abstract;
using Villa.DataAccess.Context;
using Villa.Entity.Entities;

namespace Villa.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly VillaContext _context;

        public GenericRepository(VillaContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ObjectId id)
        {
            var value = await GetByIdAsync(id);
            _context.Remove(value);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(ObjectId id)
        {
            var value = await _context.Set<T>().FindAsync(id);

            return value;
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }

        public async Task<List<T>> GetFilteredListAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<List<T>> GetListAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
