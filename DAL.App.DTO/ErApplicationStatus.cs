using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace DAL.App.DTO
{
    public class ErApplicationStatus : DomainEntityId
    {

        [MaxLength(32)] 
        public string ErApplicationStatusValue { get; set; } = default!;
        
        public ICollection<ErApplication>? ErApplications { get; set; }
    }
}