using System;
using System.Collections.Generic;

namespace Domain
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Denomination { get; set; }
        public string Description { get; set; }
        public bool State { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        /*Relacion*/
        public Guid TypeId { get; set; }
        public Type Type { get; set; }
        public ICollection<Product> Product { get; set; }
        
    }
}