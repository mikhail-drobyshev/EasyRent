using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace DAL.App.DTO
{
    public class PropertyType : DomainEntityId
    {
        [MaxLength(32)] public string PropertyTypeValue { get; set; } = default!;
        
        public ICollection<Property>? Properties { get; set; }
        
        public int? PropertiesCount { get; set; }
    }
}