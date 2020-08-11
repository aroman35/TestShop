using System;

namespace TestShop.Domain.Abstract
{
    public abstract class AggregateRoot
    {
        public Guid Id { get; protected set; }
        public DateTimeOffset CreationDate { get; protected set; }
        public DateTimeOffset LastUpdate { get; protected set; }

        public AggregateRoot(Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            CreationDate = DateTimeOffset.UtcNow;
            StateUpdated();
        }

        private protected void StateUpdated() => LastUpdate = DateTimeOffset.UtcNow;
    }
}