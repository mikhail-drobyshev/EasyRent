using System;
using Applications.Domain.Base;
using Domain.App.Identity;
using Domain.Base;

namespace Domain.App
{
    public class ErUserReview : DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {

        public int Rating { get; set; } = default!;

        public string? Comment { get; set; }

        public Guid ErUserId { get; set; }
        public ErUser? ErUser { get; set; }
        public Guid AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}