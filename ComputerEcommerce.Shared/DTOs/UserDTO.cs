using System.ComponentModel.DataAnnotations;

namespace ComputerEcommerce.Shared.DTOs
{
    public class UserDTO
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Ingrese nombre completo")]
        public string? FullName { get; set; }
        [Required(ErrorMessage = "Ingrese correo")]
        public string? Email { get; set; }
        public string? Role { get; set; }

    }
}
