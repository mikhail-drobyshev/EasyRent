using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BLL.App.DTO;
using Domain.Base;

namespace BLL.App.DTO
{
    public class ErApplicationStatus : DomainEntityId
    {

        [MaxLength(32)] 
        public string ErApplicationStatusValue { get; set; } = default!;
        
        public ICollection<ErApplication>? ErApplications { get; set; }
    }
}