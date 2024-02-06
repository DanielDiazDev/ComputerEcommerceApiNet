using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ComputerEcommerce.Data.Repositories.Contracts
{
    public interface IGenericRepository<T>
    {
        Task<bool> Insert(T entity);
        Task<T> GetById(int id);
        IQueryable<T> GetAll();
        bool Update(T entity);
        IQueryable<T> Consult(Expression<Func<T, bool>>? filter = null);
        bool Delete(T otherEntity);
    }
}
