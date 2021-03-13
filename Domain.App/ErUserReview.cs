using System;

namespace Domain.App
{
    public class ErUserReview
    {
        public Guid Id { get; set; }

        public int Rating { get; set; } = default!;

        public string? Comment { get; set; }

        public Guid ErUserId { get; set; }
        public ErUser? ErUser { get; set; }
    }
}