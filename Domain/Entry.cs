using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Entry
    {
        public Guid Id { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime Date { get; set; }
        public DateTime Total { get; set; }
        public bool State { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        /*Relacion*/
        public Guid ProviderId { get; set; }
        public Provider Provider { get; set; }

        public ICollection<DetailEntry> DetailEntries { get; set; }
    }
}