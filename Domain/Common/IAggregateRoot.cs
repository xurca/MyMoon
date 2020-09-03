using System;
using System.Collections.Generic;
using System.Text;

namespace MyMoon.Domain.Common
{
    public interface IAggregateRoot
    {
        IEnumerable<IEvent> Events { get; }
        void AddEvent(IEvent @event);
        void ClearEvents();
    }
}
