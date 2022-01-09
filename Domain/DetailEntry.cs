using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class DetailEntry
    {
        public Guid Id { get; set; }
        [Column(TypeName = "decimal(18,2)")] public Decimal Cost { get; set; }
        
        public int Quantity { get; set; }

        /*public string Batch { get; set; }
        public DateTime ExpirationDate { get; set; }*/
        public bool State { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        /*Relacion*/
        public Guid EntryId { get; set; }
        public Entry Entry { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}