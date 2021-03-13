using System;

namespace Domain.App
{
    public class PropertyReview
    {
        public Guid Id { get; set; }

        public int Rating { get; set; } = default!;

        public string? Comment { get; set; }

        public Guid PropertyId { get; set; }
        public Property? Property { get; set; }
        
        public Guid ErUserId { get; set; }
        public ErUser? ErUser { get; set; }
    }
}