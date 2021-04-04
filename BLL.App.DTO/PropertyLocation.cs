using System;
using Domain.Base;

namespace BLL.App.DTO
{
    public class PropertyLocation : DomainEntityId
    {
        public string City { get; set; } = default!;

        public string Street { get; set; } = default!;

        public int Building { get; set; } = default!;
        
        public Guid PropertyId { get; set; }
        public Property? Property { get; set; }
    }
}