﻿namespace ComputerEcommerce.Shared.DTOs
{
    public class SaleDetailDTO
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Total { get; set; }
    }
}
