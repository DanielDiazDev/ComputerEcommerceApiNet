using ComputerEcommerce.Shared.DTOs;

namespace ComputerEcommerce.Service.Contracts
{
    public interface ICategoryService
    {
        List<CategoryDTO> List(string find);
        Task<CategoryDTO> GetById(int id);
        Task<CategoryDTO> Create(CategoryDTO entity);
        Task<bool> Edit(CategoryDTO entity);
        Task<bool> Delete(int id);
    }
}
