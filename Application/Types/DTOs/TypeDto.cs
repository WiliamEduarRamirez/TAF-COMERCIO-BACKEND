using System;

namespace Application.Types.DTOs

{
    public class TypeDto
    {
        public Guid Id { get; set; }
        public string Denomination { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}