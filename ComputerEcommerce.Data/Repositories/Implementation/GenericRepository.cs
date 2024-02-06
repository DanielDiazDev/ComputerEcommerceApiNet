using ComputerEcommerce.Data.Repositories.Contracts;
using ComputerEcommerce.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace ComputerEcommerce.Data.Repositories.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        //Agregar el savechanges
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<bool> Insert(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }
        public async Task<T> GetById(int id)
        {
            try
            {
                var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
                if (entity != null)
                {
                    return entity;
                }
                return null;
            }
            catch
            {
                throw;
            }
        }
        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }
        public IQueryable<T> Consult(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = (filter == null) ? _dbSet : _dbSet.Where(filter);
            return query;
        }
        public bool Update(T entity) //Analizar
        {
            try
            {
                 _dbSet.Update(entity);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                throw;
            }
        }
        public bool Delete(T otherEntity)
        {
            try
            {
                var entity = _dbSet.FirstOrDefault(x => x.Id == otherEntity.Id);
                if (entity != null)
                {
                     _dbSet.Remove(entity);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }
    }
}
