using Microsoft.AspNetCore.Identity;

namespace ComputerEcommerce.Model
{
    public class User : IdentityUser
    {
        public string? FullName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}
