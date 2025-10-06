using RideSphere.Algorithms;
using RideSphere.Models;
using RideSphere.Services;

namespace RideSphere
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var drivers = new List<Driver>
            {
                new Driver("Amit", new Location(28.6139, 77.2090)),
                new Driver("Rohit", new Location(28.5355, 77.3910)),
                new Driver("Karan", new Location(28.7041, 77.1025))
            };

            var surgeService = new SurgePricingService();
            surgeService.UpdateZone("Zone1", riders: 20, drivers: 5); // high demand

            var rideService = new RideService(drivers, surgeService);

            var rider = new Rider("Anubhav", new Location(28.6200, 77.2300), new Location(28.4595, 77.0266));
            rideService.BookRide(rider);

            // Example Dijkstra route computation
            var graph = new Graph();
            graph.AddEdge(0, 1, 4);
            graph.AddEdge(1, 2, 6);
            graph.AddEdge(0, 2, 10);

            var dist = Dijkstra.ShortestPath(graph, 0);
            Console.WriteLine("📍 Shortest distances using Dijkstra:");
            foreach (var kv in dist)
                Console.WriteLine($"Node {kv.Key}: {kv.Value}");
        }
    }
}
