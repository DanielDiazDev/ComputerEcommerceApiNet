using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerEcommerce.Shared.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese nombre")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ingrese descripcion")]
        public string Description { get; set; }
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Ingrese precio")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Ingrese precio oferta")]
        public decimal PriceOffer { get; set; }
        [Required(ErrorMessage = "Ingrese cantidad")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Ingrese imagen")]
        public string Image { get; set; }

       // public virtual CategoryDTO? Category { get; set; }
    }
}
