using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace BLL.App.DTO
{
    public class Gender : DomainEntityId
    {

        [MaxLength(32)] public string GenderValue { get; set; } = default!;
        
        public ICollection<ErUser>? ErUsers { get; set; }
    }
}