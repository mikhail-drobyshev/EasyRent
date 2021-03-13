using System;
using Domain.Base;

namespace Domain.App
{
    public class Dispute : DomainEntityId
    {

        public string Title { get; set; } = default!;

        public string Comment { get; set; } = default!;
        
        public Guid DisputeStatusId { get; set; }
        public DisputeStatus? DisputeStatus { get; set; }
        
        public Guid ErApplicationId { get; set; }
        public ErApplication? ErApplication { get; set; }
    }
}