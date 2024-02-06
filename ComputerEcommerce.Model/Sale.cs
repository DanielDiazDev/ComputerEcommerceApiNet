namespace ComputerEcommerce.Model
{
    public class Sale : BaseModel
    {
        public string UserId { get; set; }
        public decimal Total {  get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
        public virtual User User { get; set; }

        public Sale() 
        {
            CreatedDate = DateTime.Now;
        }   

        //public Sale(string userId, decimal total)
        //{
        //    UserId = userId;
        //    Total = total;
        //    CreatedDate = DateTime.Now;
        //}
    }
}
