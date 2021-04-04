using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Applications.Domain.Base;
using DAL.App.DTO.Identity;
using Domain.Base;

namespace DAL.App.DTO
{
    public class ErUser : DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {

        [MaxLength(64)] public string FirstName { get; set; } = default!;
        [MaxLength(64)] public string LastName { get; set; } = default!;
        
        public ICollection<ErUserReview>? ErUserReviews { get; set; }
        public ICollection<Property>? Properties { get; set; }
        public ICollection<ErApplication>? ErApplications { get; set; }
        public ICollection<ErUserPicture>? ErUserPictures { get; set; }

        public int? PropertiesCount { get; set; }

        public string Gendervalue { get; set; } = default!;

        
        public Guid AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

        public string FullName => FirstName + " " + LastName;


    }
}