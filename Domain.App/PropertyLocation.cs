using System;
using System.Collections.Generic;
using Domain.Base;

namespace Domain.App
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