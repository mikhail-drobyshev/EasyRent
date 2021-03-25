using System;
using System.ComponentModel.DataAnnotations;
using Applications.Domain.Base;
using Domain.App.Identity;
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