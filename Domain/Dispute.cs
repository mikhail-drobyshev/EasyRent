using System;

namespace Domain
{
    public class Dispute : BaseEntity
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = default!;

        public string Comment { get; set; } = default!;
        
        public Guid DisputeStatusId { get; set; }
        public DisputeStatus? DisputeStatus { get; set; }
        
        public Guid ErApplicationId { get; set; }
        public ErApplication? ErApplication { get; set; }
    }
}