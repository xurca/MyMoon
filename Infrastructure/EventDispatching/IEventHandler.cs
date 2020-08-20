using MyMoon.Domain.Common;
using System.Threading.Tasks;

namespace MyMoon.Infrastructure.EventDispatching
{
    public interface IEventHandler<in T> where T : IEvent
    {
        Task HandleAsync(T @event);
    }
}
