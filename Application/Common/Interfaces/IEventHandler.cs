using MyMoon.Domain.Common;
using System.Threading.Tasks;

namespace MyMoon.Application.Common.Interfaces
{
    public interface IEventHandler<in T> where T : IEvent
    {
        Task HandleAsync(T @event);
    }
}
