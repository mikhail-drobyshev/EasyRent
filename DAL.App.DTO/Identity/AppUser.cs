using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DAL.App.DTO.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        // [StringLength(128, MinimumLength = 1)]
        // public string FirstName { get; set; } = default!;
        // [StringLength(128, MinimumLength = 1)]
        // public string LastName { get; set; } = default!;

        public ICollection<ErUser>? ErUsers { get; set; }
        [StringLength(128, MinimumLength = 1)]
        public string Firstname { get; set; } = default!;
        [StringLength(128, MinimumLength = 1)]
        public string Lastname { get; set; } = default!;
        
        public string FullName => Firstname + " " + Lastname;
        public string FullNameEmail => FullName + " (" + Email + ")";
    }
}