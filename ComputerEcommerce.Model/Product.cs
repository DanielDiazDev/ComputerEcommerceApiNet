using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerEcommerce.Model
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public decimal PriceOffer { get; set; }
        public int Quantity { get; set; }
        public string Image {  get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
        public virtual Category Category { get; set; }

        public Product(string name, string description, int categoryId, decimal price, decimal priceOffer, int quantity, string image)
        {
            Name = name;
            Description = description;
            CategoryId = categoryId;
            Price = price;
            PriceOffer = priceOffer;
            Quantity = quantity;
            Image = image;
            CreatedDate = DateTime.Now;
        }
    }
}
