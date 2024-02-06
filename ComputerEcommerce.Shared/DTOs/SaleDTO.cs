namespace ComputerEcommerce.Shared.DTOs
{
    public class SaleDTO
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public decimal Total { get; set; }

        public virtual ICollection<SaleDetailDTO> SaleDetailsDTO { get; set; } = new List<SaleDetailDTO>();
    }
}
