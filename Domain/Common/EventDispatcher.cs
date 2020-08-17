using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyMoon.Domain.Common
{
    public class EventDispatcher : IEventDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public EventDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task DispatchAsync<T>(params T[] events) where T : IEvent
        {
            foreach (var @event in events)
            {
                if (@event == null)
                    throw new ArgumentNullException(nameof(@event), "Event can not be null.");

                var eventType = @event.GetType();
                var handlerType = typeof(IEventHandler<>).MakeGenericType(eventType);

                var handler = _serviceProvider.GetService(handlerType);

                if (handler == null)
                    return;

                var method = handler.GetType()
                    .GetRuntimeMethods()
                    .First(x => x.Name.Equals("HandleAsync"));

                await (Task)((dynamic)handler).HandleAsync(@event);
            }
        }
    }
}
