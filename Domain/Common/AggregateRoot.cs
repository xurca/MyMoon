using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace MyMoon.Domain.Common
{
    public abstract class AggregateRoot : AuditableEntity, IAggregateRoot
    {
        private readonly ConcurrentDictionary<Type, IEvent> _events = new ConcurrentDictionary<Type, IEvent>();

        public IEnumerable<IEvent> Events => _events.Values;

        public void AddEvent(IEvent @event)
        {
            _events.TryAdd(@event.GetType(), @event);
        }

        public void ClearEvents()
        {
            _events.Clear();
        }
    }
}
