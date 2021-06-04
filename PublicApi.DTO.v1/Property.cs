using System;
using System.Collections.Generic;
using System.Linq;
using DAL.App.DTO;

namespace PublicApi.DTO.v1
{
    public class Property
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; } = default!;
        
        public int Price { get; set; } = default!;
        
        public string? Description { get; set; }

        public int BedroomCount { get; set; } = default!;

        public int? TenantsCount { get; set; }
        
        
        public ICollection<PropertyPicture>? PropertyPictures { get; set; }


        public Guid ErUserId { get; set; }
        public ErUser? ErUser { get; set; }

        public Guid PropertyTypeId { get; set; }
        public PropertyType? PropertyType { get; set; }
        
        
    }
}