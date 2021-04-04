using System;
using Domain.Base;

namespace BLL.App.DTO
{
    public class ErUserReview : DomainEntityId
    {

        public int Rating { get; set; } = default!;

        public string? Comment { get; set; }

        public Guid ErUserId { get; set; }
        public ErUser? ErUser { get; set; }
    }
}