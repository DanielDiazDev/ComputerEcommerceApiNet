using System.ComponentModel.DataAnnotations;

namespace ComputerEcommerce.Shared.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese nombre")]
        public string? Name { get; set; }
    }
}
