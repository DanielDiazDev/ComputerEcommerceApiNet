using ComputerEcommerce.Shared.DTOs;

namespace ComputerEcommerce.Service.Contracts
{
    public interface ISaleService
    {
        Task<SaleDTO> Register(SaleDTO entity);
    }
}
