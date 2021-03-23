using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Applications.Domain.Base;
using Domain.App.Identity;
using Domain.Base;

namespace Domain.App
{
    public class DisputeStatus : DomainEntityId
    {

        [MaxLength(32)] 
        public string DisputeStatusValue { get; set; } = default!;
        
        public ICollection<Dispute>? Disputes { get; set; }
    }
}