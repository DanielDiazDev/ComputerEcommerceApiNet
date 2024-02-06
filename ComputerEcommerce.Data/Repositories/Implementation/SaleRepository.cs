using ComputerEcommerce.Data.Repositories.Contracts;
using ComputerEcommerce.Model;

namespace ComputerEcommerce.Data.Repositories.Implementation
{
    public class SaleRepository : GenericRepository<Sale>, ISaleRepository
    {
        private readonly ApplicationDbContext _context;
        public SaleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Sale> Register(Sale entity)
        {
            Sale saleGenerated = new Sale();
            using(var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    foreach (var sd in entity.SaleDetails)
                    {
                        var product = _context.Products.Where(p => p.Id == sd.ProductId).FirstOrDefault();
                        product.Quantity -= sd.Quantity;
                        _context.Products.Update(product);
                    }
                    await _context.Sales.AddAsync(entity);
                    await _context.SaveChangesAsync();
                    saleGenerated = entity;
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
            return saleGenerated;
        }
    }
}
