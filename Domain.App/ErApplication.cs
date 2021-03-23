using System;
using Applications.Domain.Base;
using Domain.App.Identity;
using Domain.Base;

namespace Domain.App
{
    public class ErApplication : DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {
        public DateTime? RentFrom { get; set; }
        
        public string? Comment { get; set; }
        
        public Guid ErUserId { get; set; }
        public ErUser? ErUser { get; set; }
        
        public Guid PropertyId { get; set; }
        public Property? Property { get; set; }
        
        public Guid ErApplicationStatusId { get; set; }
        public ErApplicationStatus? ErApplicationStatus { get; set; }
        public Guid AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}