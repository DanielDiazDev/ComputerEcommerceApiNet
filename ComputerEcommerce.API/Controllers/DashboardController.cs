using ComputerEcommerce.Service.Contracts;
using ComputerEcommerce.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputerEcommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }
        [HttpGet("Resume")]
        public async Task<IActionResult> Resume()
        {
            var response = new ResponseDTO<DashboardDTO>();

            try
            {
                response.IsSuccess = true;
                response.Result = await _dashboardService.Resume();

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }
    }
}
