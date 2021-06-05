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
        public string CreatedBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}