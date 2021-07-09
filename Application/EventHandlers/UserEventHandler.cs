using MyMoon.Application.Common.Interfaces;
using MyMoon.Domain.UserManagement.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMoon.Application.EventHandlers
{
    public class UserEventHandler : IEventHandler<UserCreatedEvent>
    {
        public async Task HandleAsync(UserCreatedEvent @event)
        {
            await Task.CompletedTask;
        }
    }
}