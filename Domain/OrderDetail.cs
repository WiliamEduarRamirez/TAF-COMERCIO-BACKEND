using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class OrderDetail
    {
        public Guid Id { get; set; }
        [Column(TypeName = "decimal(18,2)")] public Decimal Price { get; set; }
        public int Amount { get; set; }
        public bool State { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        /*Relaciones*/
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}