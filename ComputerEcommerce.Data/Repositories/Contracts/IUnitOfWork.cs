using ComputerEcommerce.Model;

namespace ComputerEcommerce.Data.Repositories.Contracts
{
    public interface IUnitOfWork
    {
        IGenericRepository<Product> ProductRepository { get; }
        IGenericRepository<Category> CategoryRepository { get; }
        ISaleRepository SaleRepository { get; }

        Task<int> Save();
    }
}
