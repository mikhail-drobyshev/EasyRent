using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.App
{
    public class ErUserPicture
    {
        public Guid Id { get; set; }

        [MaxLength(255)] 
        public string PictureUrl { get; set; } = default!;

        public ErUser? ErUser { get; set; }
    }
}