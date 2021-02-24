using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ErUserType
    {
        public Guid Id { get; set; }

        [MaxLength(32)] 
        public string UserType { get; set; } = default!;

        public ErUser? ErUser { get; set; }
    }
}