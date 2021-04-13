using System;
using System.ComponentModel.DataAnnotations;

namespace PublicApi.DTO.v1
{
    public class ErUserAdd
    {
        [MaxLength(64)] 
        public string FirstName { get; set; } = default!;

        [MaxLength(64)] 
        public string LastName { get; set; } = default!;
    }

    public class ErUser
    {
        public Guid Id { get; set; }
        
        [MaxLength(64)] 
        public string FirstName { get; set; } = default!;

        [MaxLength(64)] 
        public string LastName { get; set; } = default!;

        public int PropertiesCount { get; set; } = default!;

        public string Gendervalue { get; set; } = default!;
    }

}