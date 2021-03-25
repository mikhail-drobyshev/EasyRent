using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Applications.Domain.Base;
using Domain.App.Identity;
using Domain.Base;

namespace Domain.App
{
    public class Gender : DomainEntityId
    {

        [MaxLength(32)] public string GenderValue { get; set; } = default!;
        
        public ICollection<ErUser>? ErUsers { get; set; }
    }
}