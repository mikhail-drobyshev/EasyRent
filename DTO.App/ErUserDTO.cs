using System;
using System.ComponentModel.DataAnnotations;
using Domain.App;

namespace DTO.App
{
    public class ErUserDTO
    {
        public Guid Id { get; set; }
        [MaxLength(64)] public string FirstName { get; set; } = default!;
        [MaxLength(64)] public string LastName { get; set; } = default!;

        public Guid? GenderId { get; set; }
        public Gender? Gender { get; set; }

        public int PropertiesCount { get; set; }

    }
}