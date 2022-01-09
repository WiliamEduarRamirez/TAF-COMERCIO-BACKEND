using System;

namespace Domain
{
    public class Provider
    {
        public Guid Id { get; set; }
        public string Names { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool State { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        /*Relacion*/
        public Entry Entry { get; set; }
    }
}