using RideSphere.Algorithms;
using System;
using System.Collections.Generic;

namespace RideSphere.Services
{
    public class RouteService
    {
        private readonly Graph _graph;

        public RouteService(Graph graph)
        {
            _graph = graph;
        }

        public void DisplayShortestRoute(int source, int destination)
        {
            // Use Dijkstra with path tracking
            var (dist, prev) = Dijkstra.ShortestPathWithPrev(_graph, source);

            if (!dist.ContainsKey(destination) || dist[destination] == double.MaxValue)
            {
                Console.WriteLine("No route found between the given locations.");
                return;
            }

            // Reconstruct path
            List<int> path = Dijkstra.GetPath(prev, destination);

            Console.WriteLine("\nShortest Path Calculation:");
            Console.WriteLine($"From Node {source} to Node {destination}");
            Console.WriteLine($"Minimum Distance: {dist[destination]:F2} km");
            Console.WriteLine("Route Path: " + string.Join(" -> ", path));
        }
    }
}
