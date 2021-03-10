using System;

namespace Applications.Domain.Base
{
    public interface IDomainEntityId : IDomainEntityId<Guid>
    {
        
    }

    public interface IDomainEntityId<TKey>
        where TKey: IEquatable<TKey>
    {
        TKey Id { get; set; }
    }
}