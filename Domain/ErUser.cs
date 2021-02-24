using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualBasic.CompilerServices;

namespace Domain
{
    public class ErUser
    {
        public Guid Id { get; set; }

        [MaxLength(64)] public string FirstName { get; set; } = default!;
        [MaxLength(64)] public string LastName { get; set; } = default!;
        
        public ICollection<ErUserReview>? ErUserReviews { get; set; }
        public ICollection<Property>? Properties { get; set; }
        public ICollection<ErApplication>? ErApplications { get; set; }

        public Guid? ErUserPictureId { get; set; }
        public ErUserPicture? ErUserPicture { get; set; }
        
        public Guid ErUserTypeId { get; set; }
        public ErUserType? ErUserType { get; set; }
        
        public Guid? GenderId { get; set; }
        public Gender? Gender { get; set; }
        
    }
}