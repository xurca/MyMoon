using MyMoon.Domain.Common;

namespace MyMoon.Domain.Entities
{
    public class Passenger : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Rating { get; set; }
        public bool IsRenter { get; set; }
        public string UserId { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        private Passenger()
        {

        }

        public Passenger(string firstName, string lastName, decimal rating, bool isRenter, string userId)
        {
            FirstName = firstName;
            LastName = lastName;
            Rating = rating;
            IsRenter = isRenter;
            UserId = userId;
        }
    }
}
