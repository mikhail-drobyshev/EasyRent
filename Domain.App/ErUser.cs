using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Applications.Domain.Base;
using Domain.App.Identity;
using Domain.Base;
using Microsoft.AspNetCore.Identity;

namespace Domain.App
{
    public class ErUser : DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {

        [MaxLength(64)] public string FirstName { get; set; } = default!;
        [MaxLength(64)] public string LastName { get; set; } = default!;
        
        public ICollection<ErUserReview>? ErUserReviews { get; set; }
        public ICollection<Property>? Properties { get; set; }
        public ICollection<ErApplication>? ErApplications { get; set; }
        public ICollection<ErUserPicture>? ErUserPictures { get; set; }

        public Guid? GenderId { get; set; }
        public Gender? Gender { get; set; }
        
        public Guid AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        

    }
}