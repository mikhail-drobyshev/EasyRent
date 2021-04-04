using System;
using Applications.Domain.Base;
using DAL.App.DTO.Identity;
using Domain.Base;

namespace DAL.App.DTO
{
    public class Dispute : DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {

        public string Title { get; set; } = default!;

        public string Comment { get; set; } = default!;
        
        public Guid DisputeStatusId { get; set; }
        public DisputeStatus? DisputeStatus { get; set; }
        
        public Guid ErApplicationId { get; set; }
        public ErApplication? ErApplication { get; set; }
        public Guid AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}