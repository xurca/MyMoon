using System;
using System.Collections.Generic;
using System.Text;

namespace MyMoon.Domain.Entities
{
    public class RoutePreference
    {
        public RoutePreference(Preference preference)
        {
            Preference = preference;
        }

        public RoutePreference(Route route, Preference preference)
        {
            Route = route;
            Preference = preference;
        }

        private RoutePreference()
        {

        }

        public int RouteId { get; private set; }
        public int PreferenceId { get; private set; }

        public Route Route { get; private set; }
        public Preference Preference { get; private set; }
    }
}
