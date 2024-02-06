using ComputerEcommerce.Data.Repositories.Contracts;
using ComputerEcommerce.Model;
using ComputerEcommerce.Service.Contracts;
using ComputerEcommerce.Shared.DTOs;
using Microsoft.AspNetCore.Identity;

namespace ComputerEcommerce.Service.Implementations
{
    public class DashboardService : IDashboardService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        // private readonly RoleManager<IdentityRole> _roleManager;

        public DashboardService(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<DashboardDTO> Resume()
        {
            try
            {
                DashboardDTO dashboardDTO = new DashboardDTO
                {
                    TotalIncomes = GetIncomes(),
                    TotalSales = GetSales(),
                    TotalCustomers = await GetCustomers(),
                    TotalProducts = GetProducts()
                };
                return dashboardDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int GetProducts()
        {
            var consutl = _unitOfWork.ProductRepository.Consult();
            var total = consutl.Count();
            return total;
        }

        private async Task<int> GetCustomers()
        {
            var users = _userManager.Users.ToList();
            var totalCustomers = 0;
            foreach (var user in users)
            {
                if (await _userManager.IsInRoleAsync(user, "usuario"))
                {
                    totalCustomers++;
                }
            }
            return totalCustomers;
        }

        private int GetSales()
        {
            var consult = _unitOfWork.SaleRepository.Consult();
            var total = consult.Count();
            return total;
        }

        private string GetIncomes()
        {
            var consult = _unitOfWork.SaleRepository.Consult();
            var incomes = consult.Sum(s => s.Total);
            return Convert.ToString(incomes);
        }
    }
}
