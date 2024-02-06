using ComputerEcommerce.Service.Contracts;
using ComputerEcommerce.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputerEcommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }
        [HttpGet("List/{find?}")]
        public IActionResult List(string find = "NA")
        {
            var response = new ResponseDTO<List<CategoryDTO>>();
            _logger.LogInformation("Parámetro find: {Find}", find);
            try
            {
                if (find == "NA")
                {
                    find = "";
                }
                response.IsSuccess = true;
                response.Result = _categoryService.List(find);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError(ex, "Error al listar categorías: {ErrorMessage}", ex.Message);
            }
            return Ok(response);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CategoryDTO categoryDTO)
        {
            var response = new ResponseDTO<CategoryDTO>();
            try
            {
                response.IsSuccess = true;
                response.Result = await _categoryService.Create(categoryDTO);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }
        [HttpGet("Get/{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = new ResponseDTO<CategoryDTO>();
            try
            {
                response.IsSuccess = true;
                response.Result = await _categoryService.GetById(id);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit([FromBody] CategoryDTO categoryDTO)
        {
            var response = new ResponseDTO<bool>();

            try
            {

                response.IsSuccess = true;
                response.Result = await _categoryService.Edit(categoryDTO);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = new ResponseDTO<bool>();

            try
            {

                response.IsSuccess = true;
                response.Result = await _categoryService.Delete(id);

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
