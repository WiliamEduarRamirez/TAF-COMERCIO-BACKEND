using System;

namespace Application.Types.DTOs
{
    public class TypeCreateDto
    {
        public Guid Id { get; set; }
        public string Denomination { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }
    }
}