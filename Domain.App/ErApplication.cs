using System;

namespace Domain.App
{
    public class ErApplication
    {
        public Guid Id { get; set; }
        
        public DateTime? RentFrom { get; set; }
        
        public string? Comment { get; set; }
        
        public Guid ErUserId { get; set; }
        public ErUser? ErUser { get; set; }
        
        public Guid PropertyId { get; set; }
        public Property? Property { get; set; }
        
        public Guid ErApplicationStatusId { get; set; }
        public ErApplicationStatus? ErApplicationStatus { get; set; }
    }
}