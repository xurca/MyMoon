using MyMoon.Domain.Common;
using System.Threading.Tasks;

namespace MyMoon.Infrastructure.EventDispatching
{
    public interface IEventDispatcher
    {
        Task DispatchAsync<T>(params T[] events) where T : IEvent;
    }
}
