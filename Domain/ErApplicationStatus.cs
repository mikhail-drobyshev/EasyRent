using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ErApplicationStatus
    {
        public Guid Id { get; set; }

        [MaxLength(32)] 
        public string ErApplicationStatusValue { get; set; } = default!;
        
        public ICollection<ErApplication>? ErApplications { get; set; }
    }
}