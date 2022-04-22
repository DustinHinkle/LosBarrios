#nullable disable
using LosBarriosDomain;
using Microsoft.EntityFrameworkCore;

namespace Repository;

    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly webappDbContext _context;

        protected GenericRepository(webappDbContext context)
        {
            _context = context;
        }
        public async Task<T> Get(string id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }

