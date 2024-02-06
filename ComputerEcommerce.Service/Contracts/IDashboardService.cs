using ComputerEcommerce.Shared.DTOs;

namespace ComputerEcommerce.Service.Contracts
{
    public interface IDashboardService
    {
        Task<DashboardDTO?> Resume();
    }
}
