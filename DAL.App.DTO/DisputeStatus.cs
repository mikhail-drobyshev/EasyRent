using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace DAL.App.DTO
{
    public class DisputeStatus : DomainEntityId
    {

        [MaxLength(32)] 
        public string DisputeStatusValue { get; set; } = default!;
        
        public ICollection<Dispute>? Disputes { get; set; }
    }
}