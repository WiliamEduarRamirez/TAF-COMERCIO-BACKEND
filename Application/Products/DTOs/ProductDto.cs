using System;
using Application.Categories.DTOs;
using Application.Types.DTOs;

namespace Application.Products.DTOs


{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public Guid TypeId { get; set; }
        public string Code { get; set; }
        public string Denomination { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public Decimal Cost { get; set; }
        public Decimal Price { get; set; }
        public bool State { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public TypeDto Type { get; set; }
        public CategoryDto Category { get; set; }
    }
}