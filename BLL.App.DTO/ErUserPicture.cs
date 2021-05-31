using System;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace BLL.App.DTO
{
    public class ErUserPicture : DomainEntityId
    {
        [MaxLength(255)]
        public string PictureUrl { get; set; } = default!;

        public Guid ErUserId { get; set; }
        public ErUser? ErUser { get; set; }
    }
}