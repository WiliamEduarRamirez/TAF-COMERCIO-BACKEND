using System;

namespace Application.Categories.DTOs
{
    public class CategoryCreatedDto
    {
        public Guid Id { get; set; }
        public string Denomination { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }
        public Guid TypeId { get; set; }
    }
}