using MyMoon.Domain.Common;
using MyMoon.Domain.Enums;
using System;

namespace MyMoon.Domain.Entities
{
    public class Route : AuditableEntity
    {
        public string Location { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public LagguageSize? LagguageSize { get; set; }
        public int? PassengerId { get; set; }
        public Passenger Passenger { get; private set; }

        private Route()
        {

        }

        public Route(string location, string destination, DateTime departureTime, LagguageSize? lagguageSize, int? passengerId)
        {
            Location = location;
            Destination = destination;
            DepartureTime = departureTime;
            LagguageSize = lagguageSize;
            PassengerId = passengerId;
        }
    }
}
