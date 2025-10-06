using RideSphere.Algorithms;
using RideSphere.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public Driver FindNearestDriver(Location riderPickup, VehicleType preferredVehicle)
        {
            var nearestDrivers = KNNFinder
                .FindNearestDrivers(_drivers.Where(d => d.Vehicle == preferredVehicle).ToList(), riderPickup, 3);
            return nearestDrivers.FirstOrDefault();
        }



        public void BookRideWithRoute(Rider rider, VehicleType vehicleType, Graph cityGraph)
        {
            var driver = FindNearestDriver(rider.Pickup, vehicleType);
            if (driver == null)
            {
                Console.WriteLine("❌ No drivers available.");
                return;
            }

            int driverNode = driver.CurrentLocation.NodeId;
            int pickupNode = rider.Pickup.NodeId;
            int dropNode = rider.Drop.NodeId;

            // Compute driver to pickup
            var (distDriverToPickup, prevDriverToPickup) = Dijkstra.ShortestPathWithPrev(cityGraph, driverNode);
            var pathDriverToPickup = Dijkstra.GetPath(prevDriverToPickup, pickupNode);

            // Compute pickup to drop
            var (distPickupToDrop, prevPickupToDrop) = Dijkstra.ShortestPathWithPrev(cityGraph, pickupNode);
            var pathPickupToDrop = Dijkstra.GetPath(prevPickupToDrop, dropNode);

            double totalDistance = distDriverToPickup[pickupNode] + distPickupToDrop[dropNode];
            double surge = _surgePricingService.GetSurgeFactor("Zone1");
            double totalFare = FareCalculator.CalculateFare(totalDistance, driver.Vehicle, surge);

            driver.AssignRide();

            Console.WriteLine($"\nRide Confirmed:");
            Console.WriteLine($"Driver: {driver.Name}");
            Console.WriteLine($"Vehicle: {driver.Vehicle}");
            Console.WriteLine($"Total Distance: {totalDistance:F2} km");
            Console.WriteLine($"Total Fare: Rs {totalFare:F2}");

            Console.WriteLine("\nRoute from Driver to Pickup:");
            Console.WriteLine(string.Join(" -> ", pathDriverToPickup));

            Console.WriteLine("Route from Pickup to Drop:");
            Console.WriteLine(string.Join(" -> ", pathPickupToDrop));

            driver.CompleteRide(rider.Drop);
        }


        public void CancelRide(Driver driver)
        {
            driver.CancelRide();
            Console.WriteLine($"Ride cancelled. Driver {driver.Name} is now available.");
        }
    }
}
