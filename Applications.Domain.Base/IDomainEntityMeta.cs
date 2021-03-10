using System;

namespace Applications.Domain.Base
{
    public interface IDomainEntityMeta
    {
        string CreatedBy { get; set; }
        DateTime CreateAt { get; set; }
        
        string UpdateBy { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}