using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("Photos")]
    public class Photo
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public bool State { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        /*Relacion*/
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}