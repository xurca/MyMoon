using MyMoon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMoon.Domain.Entities
{
    public class Route : AuditableEntity
    {
        public string Location { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public int? LagguageSize { get; set; }
        public int? PassengerId { get; set; }
        public Passenger Passenger { get; set; }

        private Route()
        {

        }

        public Route(string location, string destination, DateTime departureTime, int? lagguageSize, int? passengerId)
        {
            Location = location;
            Destination = destination;
            DepartureTime = departureTime;
            LagguageSize = lagguageSize;
            PassengerId = passengerId;
        }
    }
}
