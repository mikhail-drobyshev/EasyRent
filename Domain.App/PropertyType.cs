using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.App
{
    public class PropertyType
    {
        public Guid Id { get; set; }

        [MaxLength(32)] public string PropertyTypeValue { get; set; } = default!;
        
        public ICollection<Property>? Properties { get; set; }
    }
}