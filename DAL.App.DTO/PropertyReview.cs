using System;
using Domain.Base;

namespace DAL.App.DTO
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