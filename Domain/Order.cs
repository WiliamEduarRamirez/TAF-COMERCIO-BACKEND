using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        [Column(TypeName = "decimal(18,2)")] public Decimal Total { get; set; }
        public bool State { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        /*Relaciones*/
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
    }
}