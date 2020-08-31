using MyMoon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMoon.Domain.UserManagement.Events
{
    public class UserCreatedEvent : IEvent
    {
        public UserCreatedEvent(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
