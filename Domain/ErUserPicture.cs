using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class ErUserPicture
    {
        public Guid Id { get; set; }

        [MaxLength(255)] 
        public string PictureUrl { get; set; } = default!;

        public ErUser? ErUser { get; set; }
    }
}