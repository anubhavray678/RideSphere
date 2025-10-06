using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideSphere.Models
{
    public class Driver
    {
        public string Name { get; }
        public Location CurrentLocation { get; private set; }
        public bool IsAvailable { get; private set; }

        public Driver(string name, Location location)
        {
            Name = name;
            CurrentLocation = location;
            IsAvailable = true;
        }

        public void AssignRide() => IsAvailable = false;
        public void CompleteRide(Location newLocation)
        {
            IsAvailable = true;
            CurrentLocation = newLocation;
        }
    }
}
