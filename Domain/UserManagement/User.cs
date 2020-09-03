using Microsoft.AspNetCore.Identity;
using MyMoon.Domain.Common;
using MyMoon.Domain.Entities;
using MyMoon.Domain.Enums;
using MyMoon.Domain.UserManagement.Events;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace MyMoon.Domain.UserManagement
{
    public class User : IdentityUser<int>, IAggregateRoot
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Gender? Gender { get; private set; }
        public int Age { get; private set; }
        public decimal Rating { get; private set; }
        public string About { get; private set; }
        public Photo ProfilePicture { get; private set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        private User()
        {

        }

        public User(string firstName, string lastName, Gender? gender, string email, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Email = email;
            PhoneNumber = phone;
            UserName = email;

            AddEvent(new UserCreatedEvent(Id));
        }

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

    public class UserClaim : IdentityUserClaim<int>
    {
    }

    public class UserLogin : IdentityUserLogin<int>
    {
        public virtual int Id { get; set; }
    }

    public class UserRole : IdentityUserRole<int>
    {
        public virtual int Id { get; set; }
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }

    public class UserToken : IdentityUserToken<int>
    {
        public virtual int Id { get; set; }
    }
}