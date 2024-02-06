using ComputerEcommerce.Data.Repositories.Contracts;
using ComputerEcommerce.Model;

namespace ComputerEcommerce.Data.Repositories.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IGenericRepository<Product> ProductRepository { get; }
        public IGenericRepository<Category> CategoryRepository { get; }
        public ISaleRepository SaleRepository { get; }
        public UnitOfWork(ApplicationDbContext context, IGenericRepository<Product> productRepository, IGenericRepository<Category> categoryRepository, ISaleRepository saleRepository)
        {
            _context = context;
            ProductRepository = productRepository;
            CategoryRepository = categoryRepository;
            SaleRepository = saleRepository;
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
