using System;
using System.Collections.Generic;
using Applications.Domain.Base;
using Domain.App.Identity;
using Domain.Base;

namespace Domain.App
{
    public class PropertyLocation : DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {
        public string City { get; set; } = default!;

        public string Street { get; set; } = default!;

        public int Building { get; set; } = default!;
        
        public Guid PropertyId { get; set; }
        public Property? Property { get; set; }
        public Guid AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}