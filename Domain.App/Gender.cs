using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Applications.Domain.Base;
using Domain.App.Identity;
using Domain.Base;

namespace Domain.App
{
    public class Gender : DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {

        [MaxLength(32)] public string GenderValue { get; set; } = default!;
        
        public ICollection<ErUser>? ErUsers { get; set; }
        public Guid AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}