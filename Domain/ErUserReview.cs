using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ErUserReview : BaseEntity
    {
        public Guid Id { get; set; }

        public string Rating { get; set; } = default!;

        public string? Comment { get; set; }

        public Guid ErUserId { get; set; }
        public ErUser? ErUser { get; set; }
    }
}