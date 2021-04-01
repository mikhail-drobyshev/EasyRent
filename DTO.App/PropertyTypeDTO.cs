using System;
using System.ComponentModel.DataAnnotations;

namespace DTO.App
{
    public class PropertyTypeDTO
    {
        public Guid Id { get; set; }
        [MaxLength(32)] 
        public string PropertyTypeValue { get; set; } = default!;
        
        public int PropertyCount { get; set; }
    }
}