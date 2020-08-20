using MyMoon.Domain.Common;
using MyMoon.Domain.Enums;

namespace MyMoon.Domain.Entities
{
    public class User : AuditableEntity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public Gender Gender { get; private set; }
        public int Age { get; private set; }
        public decimal Rating { get; private set; }
        public string About { get; private set; }
        public string Phone { get; private set; }
        public bool PhoneVerified { get; private set; }
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

        public User(string firstName, string lastName, string email, Gender gender, int age, decimal rating, string about = null, string phone = null, bool phoneVerified = false, Photo profilePicture = null)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Gender = gender;
            Age = age;
            Rating = rating;
            About = about;
            Phone = phone;
            PhoneVerified = phoneVerified;
            ProfilePicture = profilePicture;
        }
    }
}