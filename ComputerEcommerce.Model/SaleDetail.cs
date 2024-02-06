namespace ComputerEcommerce.Model
{
    public class SaleDetail : BaseModel
    {
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public virtual Product Product { get; set; }
        public virtual Sale Sale { get; set; }

        //public SaleDetail(int saleId, int productId, int quantity, decimal total)
        //{
        //    SaleId = saleId;
        //    ProductId = productId;
        //    Quantity = quantity;
        //    Total = total;
        //}
    }
}
