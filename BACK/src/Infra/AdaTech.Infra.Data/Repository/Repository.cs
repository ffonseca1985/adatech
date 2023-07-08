using AdaTech.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AdaTech.Infra.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _table;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task DeleteAsync(object id)
        {
            var search = await _table.FindAsync(id);

            if (search != null)
            {
                _table.Remove(search);
                return;
            }
        }

        public Task<T?> GetFirstAsync(Func<T, bool> funcFilter)
        {
            try
            {
                var result = _table.FirstOrDefault(funcFilter);
                return Task.FromResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<IEnumerable<T>> GetAsync(Func<T, bool> funcFilter)
        {
            try
            {
                var result = _table.Where(funcFilter).AsEnumerable();
                return Task.FromResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                var result = await _table.ToListAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task InsertAsync(T obj)
        {
            try
            {
               await _table.AddAsync(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task SaveChangesAsync()
        {
            try
            {
               await  _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<T> UpdateAsync(T obj)
        {
            try
            {
                _table.Attach(obj);
                _context.Entry(obj).State = EntityState.Modified;

                return Task.FromResult(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<T?> GetByIdDetached(object id)
        {
            try
            {
                var search = await _table.FindAsync(id);

                if (search != null)
                {
                    _context.Entry(search).State = EntityState.Detached;
                }

                return search;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
