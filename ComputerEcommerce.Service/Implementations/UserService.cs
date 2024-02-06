using AutoMapper;
using ComputerEcommerce.Data.Repositories.Contracts;
using ComputerEcommerce.Model;
using ComputerEcommerce.Service.Contracts;
using ComputerEcommerce.Shared.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Authentication;

namespace ComputerEcommerce.Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<SessionDTO> Authorization(LoginDTO entity)
        {
            var user = await _userManager.FindByEmailAsync(entity.Email);
            if(user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, entity.Password, false, false);
                if(result.Succeeded)
                {
                    return new SessionDTO
                    {
                        UserId = user.Id,
                        FullName = user.FullName,
                        Email = user.Email,
                        Role = (await _userManager.GetRolesAsync(user)).FirstOrDefault()
                    };
                }
            }
            throw new AuthenticationException("Credenciales invalidas");
        }

        public async Task<bool> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if(user == null)
            {
                return false;
            }
            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> Edit(UserDTO entity)
        {
            var user = await _userManager.FindByIdAsync(entity.Id);
            if (user == null)
            {
                return false;
            }

            user.Email = entity.Email;
            user.FullName = entity.FullName;
            // Actualizar otros campos si es necesario

            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        public async Task<UserDTO> GetById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return null;
            }

            var userDTO = _mapper.Map<UserDTO>(user);
            userDTO.Role = await GetRoles(user.Id);
            return userDTO;
        }

        

        public async Task<List<UserDTO>> List(string role, string find)
        {
            var users = await _userManager.Users.ToListAsync();
            if (!string.IsNullOrWhiteSpace(role))
            {
                users = users.Where(u => _userManager.IsInRoleAsync(u, role).Result).ToList();
            }
            if (!string.IsNullOrWhiteSpace(find))
            {
                users = users.Where(u => u.FullName.Contains(find) || u.Email.Contains(find)).ToList();
            }

            var usersDTO = _mapper.Map<List<UserDTO>>(users);
            for (int i = 0; i < usersDTO.Count; i++)
            {
                usersDTO[i].Role = await GetRoles(usersDTO[i].Id);

            }
            return usersDTO;
        }

        public async Task<UserDTO> Register(RegisterDTO entity)
        {
            if (entity.Password != entity.ConfirmPassword)
            {
                throw new ArgumentException("Las contraseñas no coinciden.");
            }
            var role = new IdentityRole();
            role.Name = "usuario";
            await _roleManager.CreateAsync(role);

            var user = new User
            {
                UserName = entity.Email, // Normalmente el nombre de usuario y el email son el mismo en Identity
                Email = entity.Email,
                FullName = entity.FullName,
                CreatedDate = DateTime.UtcNow // Asumiendo que quieres registrar la fecha de creación
            };

            var result = await _userManager.CreateAsync(user, entity.Password);

            if (!result.Succeeded)
            {
                throw new InvalidOperationException("No se pudo crear el usuario: " + result.Errors.FirstOrDefault()?.Description);
            }

            // Asignar rol al usuario si se proporciona uno
            if (!string.IsNullOrWhiteSpace(entity.Role))
            {
                await _userManager.AddToRoleAsync(user, entity.Role);
            }

            var userDTO = _mapper.Map<UserDTO>(user);
            userDTO.Role = await GetRoles(user.Id);
            return userDTO;
        }
        private async Task<string?> GetRoles(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var userDTO = new UserDTO
            {
                Role = roles.FirstOrDefault()
            };
            return userDTO.Role;
        }
    }
}
