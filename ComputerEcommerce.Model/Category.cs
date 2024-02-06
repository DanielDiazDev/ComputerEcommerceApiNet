namespace ComputerEcommerce.Model
{
    public class Category : BaseModel
    {
        public string? Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

        public Category(string? name)
        {
            Name = name;
            CreatedDate = DateTime.Now;
        }
    }
}
