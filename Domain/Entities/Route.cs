using MyMoon.Domain.Common;
using MyMoon.Domain.Enums;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MyMoon.Domain.Entities
{
    public class Route : AggregateRoot
    {
        public string Location { get; private set; }
        public string Destination { get; private set; }
        public DateTime DepartureTime { get; private set; }
        public DateTime ArrivalTime { get; private set; }
        public LagguageSize? LagguageSize { get; private set; }
        public int? UserId { get; private set; }
        public User User { get; private set; }
        public decimal PricePerSeat { get; private set; }
        public decimal TotalSeats { get; private set; }

        public ICollection<RoutePreference> Preferences { get; private set; }

        private Route()
        {

        }

        public Route(string location, string destination, DateTime departureTime, DateTime arrivalTime, LagguageSize? lagguageSize, User user, decimal pricePerSeat, decimal totalSeats, ICollection<RoutePreference> preferences = null)
        {
            Location = location;
            Destination = destination;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            LagguageSize = lagguageSize;
            User = user;
            PricePerSeat = pricePerSeat;
            TotalSeats = totalSeats;
            Preferences = preferences;

            Preferences = new HashSet<RoutePreference>();
        }

        public void WithPreference(Preference preference)
        {
            Preferences.Add(new RoutePreference(preference));
        }
    }
}