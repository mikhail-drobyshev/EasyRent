using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.App
{
    public class Gender
    {
        public Guid Id { get; set; }

        [MaxLength(32)] public string GenderValue { get; set; } = default!;
        
        public ICollection<ErUser>? ErUsers { get; set; }
    }
}