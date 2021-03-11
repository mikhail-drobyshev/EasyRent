using System;
using System.Collections.Generic;

namespace Domain
{
    public class PropertyLocation
    {
        public Guid Id { get; set; }
        
        public string City { get; set; } = default!;

        public string Street { get; set; } = default!;

        public int Building { get; set; } = default!;
        
        public ICollection<ErUser>? ErUsers { get; set; }
    }
}