using System;
using System.ComponentModel.DataAnnotations.Schema;
using Applications.Domain.Base;
using Microsoft.VisualBasic;

namespace Domain.Base
{
    public abstract class DomainEntityId: DomainEntityId<Guid>, IDomainEntityId
    {
    }

    public abstract class DomainEntityId<TKey>: IDomainEntityId<TKey> 
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; } = default!;
        public string CreatedBy { get; set; } = "system";
        public DateTime CreateAt { get; set; }
        public string UpdateBy { get; set; } = "system";
        public DateTime UpdatedAt { get; set; }
    }
}