using RideSphere.Algorithms;
using RideSphere.Models;
using RideSphere.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RideSphere
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  Setup Drivers
            var drivers = new List<Driver>
            {
                new Driver("Amit", new Location(28.6139, 77.2090, 1), VehicleType.Sedan),
                new Driver("Rohit", new Location(28.5355, 77.3910, 2), VehicleType.Bike),
                new Driver("Karan", new Location(28.7041, 77.1025, 3), VehicleType.SUV)
            };

            // Setup Surge Pricing
            var surgeService = new SurgePricingService();
            surgeService.UpdateZone("Zone1", riders: 20, drivers: 5);

            // Setup Ride Service
            var rideService = new RideService(drivers, surgeService);

            //  Input Rider Coordinates
            Console.WriteLine("Welcome to RideSphere!\n");
            Console.WriteLine("Enter Pickup Location Coordinates:");
            Console.Write("Latitude: "); double pickupLat = double.Parse(Console.ReadLine() ?? "0");
            Console.Write("Longitude: "); double pickupLon = double.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine("Enter Drop Location Coordinates:");
            Console.Write("Latitude: "); double dropLat = double.Parse(Console.ReadLine() ?? "0");
            Console.Write("Longitude: "); double dropLon = double.Parse(Console.ReadLine() ?? "0");

            var rider = new Rider("You", new Location(pickupLat, pickupLon, 4), new Location(dropLat, dropLon, 5));

            // Show fares for vehicle types
            double tripDistance = DistanceCalculator.Haversine(rider.Pickup, rider.Drop);
            Console.WriteLine("\nAvailable Vehicle Types and Approx. Fare:");
            foreach (VehicleType vehicle in Enum.GetValues(typeof(VehicleType)))
            {
                double fare = FareCalculator.CalculateFare(tripDistance, vehicle, surgeService.GetSurgeFactor("Zone1"));
                Console.WriteLine($"{(int)vehicle} - {vehicle}: Rs{fare:F2}");
            }

            // Choose vehicle
            Console.Write("\nSelect Vehicle Type (Bike=0, Sedan=1, SUV=2): ");
            int vehicleChoice = int.Parse(Console.ReadLine() ?? "1");
            VehicleType selectedVehicle = (VehicleType)vehicleChoice;

            // Create sample city graph
            var cityGraph = new Graph();
            cityGraph.AddEdge(1, 2, 4);
            cityGraph.AddEdge(1, 3, 2);
            cityGraph.AddEdge(2, 4, 6);
            cityGraph.AddEdge(3, 4, 5);
            cityGraph.AddEdge(4, 5, 3); // Rider drop node

            // Book ride with Dijkstra route
            rideService.BookRideWithRoute(rider, selectedVehicle, cityGraph);

            // Show booked driver's current location
            var bookedDriver = drivers.FirstOrDefault(d => !d.IsAvailable && d.Vehicle == selectedVehicle);
            if (bookedDriver != null)
            {
                Console.WriteLine($"\nDriver Current Location:");
                Console.WriteLine($"Name: {bookedDriver.Name}");
                Console.WriteLine($"Vehicle: {bookedDriver.Vehicle}");
                Console.WriteLine($"Latitude: {bookedDriver.CurrentLocation.Latitude}");
                Console.WriteLine($"Longitude: {bookedDriver.CurrentLocation.Longitude}");
            }

            // 9Option to cancel
            Console.Write("\nDo you want to cancel the ride? (y/n): ");
            if ((Console.ReadLine()?.ToLower() ?? "n") == "y")
            {
                if (bookedDriver != null)
                    rideService.CancelRide(bookedDriver);
                else
                    Console.WriteLine("No ride to cancel.");
            }

            Console.WriteLine("\nThank you for using RideSphere!");
        }
    }
}
