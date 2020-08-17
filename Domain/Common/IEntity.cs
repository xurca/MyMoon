using System;
using System.Collections.Generic;
using System.Text;

namespace MyMoon.Domain.Common
{
    public interface IEntity
    {
        IEnumerable<IEvent> Events { get; }
    }
}
