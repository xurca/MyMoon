using MyMoon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMoon.Domain.Entities
{
    public class Passenger : BaseEntity
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
    }
}
