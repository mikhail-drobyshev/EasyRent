using System;

namespace Domain
{
    public class PropertyLocation
    {
        public Guid Id { get; set; }
        
        public string City { get; set; } = default!;

        public string Street { get; set; } = default!;

        public int Building { get; set; } = default!;
        
        public Guid PropertyId { get; set; }
        public Property? Property { get; set; }
    }
}