using MyMoon.Domain.Common;
using MyMoon.Domain.Enums;
using MyMoon.Domain.UserManagement;

namespace MyMoon.Domain.Entities
{
    public class User : AuditableEntity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Gender Gender { get; private set; }
        public int Age { get; private set; }
        public decimal Rating { get; private set; }
        public string About { get; private set; }
        public Photo ProfilePicture { get; private set; }

        public AppUser AppUser { get; private set; }

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

        public User(string firstName, string lastName, Gender gender, int age, decimal rating, string about, Photo profilePicture)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Age = age;
            Rating = rating;
            About = about;
            ProfilePicture = profilePicture;
        }
    }
}