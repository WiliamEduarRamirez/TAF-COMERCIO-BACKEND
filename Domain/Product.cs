using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Denomination { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,2)")] public Decimal Cost { get; set; }
        [Column(TypeName = "decimal(18,2)")] public Decimal Price { get; set; }
        public int Stock { get; set; }
        public bool State { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        /*Relacion*/
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public Guid TypeId { get; set; }
        public Type Type { get; set; }

        public ICollection<DetailEntry> DetailEntries { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}