using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.App
{
    public class DisputeStatus
    {
        public Guid Id { get; set; }

        [MaxLength(32)] 
        public string DisputeStatusValue { get; set; } = default!;
        
        public ICollection<Dispute>? Disputes { get; set; }
    }
}