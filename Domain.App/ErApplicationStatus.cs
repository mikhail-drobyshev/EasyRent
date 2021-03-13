using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.App
{
    public class ErApplicationStatus
    {
        public Guid Id { get; set; }

        [MaxLength(32)] 
        public string ErApplicationStatusValue { get; set; } = default!;
        
        public ICollection<ErApplication>? ErApplications { get; set; }
    }
}