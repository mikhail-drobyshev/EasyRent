using System;
using Applications.Domain.Base;
using Domain.App.Identity;
using Domain.Base;

namespace Domain.App
{
    public class PropertyReview : DomainEntityId
    {
        public int Rating { get; set; } = default!;

        public string? Comment { get; set; }

        public Guid PropertyId { get; set; }
        public Property? Property { get; set; }
        
        public Guid ErUserId { get; set; }
        public ErUser? ErUser { get; set; }
    }
}