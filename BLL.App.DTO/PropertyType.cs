using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace BLL.App.DTO
{
    public class PropertyType : DomainEntityId
    {
        [MaxLength(32)] 
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.PropertyType), Name = nameof(PropertyTypeValue))]
        public string PropertyTypeValue { get; set; } = default!;
        
        public int? PropertiesCount { get; set; }
    }
}