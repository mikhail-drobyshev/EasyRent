using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using Microsoft.AspNetCore.Identity;

namespace Domain.App.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        // [StringLength(128, MinimumLength = 1)]
        // public string FirstName { get; set; } = default!;
        // [StringLength(128, MinimumLength = 1)]
        // public string LastName { get; set; } = default!;

        public ICollection<ErUser>? ErUsers { get; set; }
    }
}