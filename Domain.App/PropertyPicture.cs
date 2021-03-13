using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.App
{
    public class PropertyPicture
    {
        public Guid Id { get; set; }

        [MaxLength(255)] 
        public string PictureUrl { get; set; } = default!;

        [MaxLength(15)]
        public string Title { get; set; } = default!;
        
        public Guid PropertyId { get; set; }
        public Property? Property { get; set; }
    }
}