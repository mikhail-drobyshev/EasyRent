using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ErUser
    {
        public Guid Id { get; set; }

        [MaxLength(128)] public string Name { get; set; } = default!;
        
        public Guid GenderId { get; set; }
        public Gender? Gender { get; set; }
    }
}