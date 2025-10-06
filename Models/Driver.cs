using System;

namespace RideSphere.Models
{
    public class Driver
    {
        public string Name { get; set; }
        public Location CurrentLocation { get; set; }
        public bool IsAvailable { get; set; } = true;
        public VehicleType Vehicle { get; set; }

        public Driver(string name, Location location, VehicleType vehicle)
        {
            Name = name;
            CurrentLocation = location;
            Vehicle = vehicle;
        }

        public void AssignRide() => IsAvailable = false;
        public void CompleteRide(Location dropLocation)
        {
            CurrentLocation = dropLocation;
            IsAvailable = true;
        }

        public void CancelRide() => IsAvailable = true;
    }
}
