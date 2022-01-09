using System;

namespace Application.Products.DTOs
{
    public class ProductCreatedDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Denomination { get; set; }
        public string Description { get; set; }
        public Decimal Cost { get; set; }
        public Decimal Price { get; set; }
        public bool State { get; set; }
        public int Stock { get; set; }
        public Guid CategoryId { get; set; }
        public Guid TypeId { get; set; }
    }
}