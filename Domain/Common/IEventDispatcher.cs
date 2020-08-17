using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMoon.Domain.Common
{
    public interface IEventDispatcher
    {
        Task DispatchAsync<T>(params T[] events) where T : IEvent;
    }
}
