using ComputerEcommerce.Model;

namespace ComputerEcommerce.Data.Repositories.Contracts
{
    public interface ISaleRepository : IGenericRepository<Sale>
    {
        Task<Sale> Register(Sale entity);
    }
}
