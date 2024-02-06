using ComputerEcommerce.Shared.DTOs;

namespace ComputerEcommerce.Service.Contracts
{
    public interface IUserService
    {
        Task<List<UserDTO>> List(string role, string find);
        Task<UserDTO> GetById(string id);
        Task<SessionDTO> Authorization(LoginDTO entity);
        Task<UserDTO> Register(RegisterDTO entity);
        Task<bool> Edit(UserDTO entity);
        Task<bool> Delete(string id);
    }
}
