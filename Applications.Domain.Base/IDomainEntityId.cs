using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Applications.Domain.Base
{
    public interface IDomainEntityId : IDomainEntityId<Guid>
    {
        
    }

    public interface IDomainEntityId<TKey>
        where TKey: IEquatable<TKey>
    {
        TKey Id { get; set; }
        string CreatedBy { get; set; }
        DateTime CreateAt { get; set; }
        string UpdateBy { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}