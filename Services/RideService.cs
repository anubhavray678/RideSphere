using RideSphere.Algorithms;
using RideSphere.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideSphere.Services
{
    public class RideService
    {
        private readonly List<Driver> _drivers;
        private readonly SurgePricingService _surgePricingService;

        public RideService(List<Driver> drivers, SurgePricingService surgeService)
        {
            _drivers = drivers;
            _surgePricingService = surgeService;
        }

        public Driver FindNearestDriver(Location riderPickup)
        {
            
            var nearestDrivers = KNNFinder.FindNearestDrivers(_drivers, riderPickup, 3);
            return nearestDrivers.FirstOrDefault();
        }

        public void BookRide(Rider rider)
        {
            var driver = FindNearestDriver(rider.Pickup);
            if (driver == null)
            {
                Console.WriteLine("❌ No drivers available.");
                return;
            }

            double tripDistance = DistanceCalculator.Haversine(rider.Pickup, rider.Drop);
            double baseFare = 50 + tripDistance * 10;
            double surge = _surgePricingService.GetSurgeFactor("Zone1");
            double totalFare = baseFare * surge;

            driver.AssignRide();

            Console.WriteLine($"\n🚗 Ride Confirmed:");
            Console.WriteLine($"Driver: {driver.Name}");
            Console.WriteLine($"Distance: {tripDistance:F2} km");
            Console.WriteLine($"Surge Factor: x{surge:F2}");
            Console.WriteLine($"Total Fare: ₹{totalFare:F2}\n");

            driver.CompleteRide(rider.Drop);
        }
    }
}
