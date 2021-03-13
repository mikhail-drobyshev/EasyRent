using System;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace Domain.App
{
    public class ErUserPicture : DomainEntityId
    {
        [MaxLength(255)] 
        public string PictureUrl { get; set; } = default!;

        public ErUser? ErUser { get; set; }
    }
}