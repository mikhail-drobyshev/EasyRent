using System;
using System.Collections.Generic;
using BLL.App.DTO;
using DAL.App.DTO;
using Domain.Base;

namespace BLL.App.DTO
{
    public class Property : DomainEntityId
    {
        public string Title { get; set; } = default!;
        
        public int Price { get; set; } = default!;
        
        public string? Description { get; set; }

        public int BedroomCount { get; set; } = default!;

        public int? TenantsCount { get; set; }
        
        
        public ICollection<PropertyReview>? PropertyReviews { get; set; }
        public ICollection<PropertyPicture>? PropertyPictures { get; set; }
        public ICollection<ErApplication>? ErApplications { get; set; }
        public PropertyLocation? PropertyLocation { get; set; }

        public Guid ErUserId { get; set; }
        public ErUser? ErUser { get; set; }

        public Guid PropertyTypeId { get; set; }
        public PropertyType? PropertyType { get; set; }
        
        
    }
}