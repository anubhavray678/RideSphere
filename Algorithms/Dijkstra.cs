using System;
using System.Collections.Generic;
using System.Linq;

namespace RideSphere.Algorithms
{
    public static class Dijkstra
    {
        public static (Dictionary<int, double> dist, Dictionary<int, int> prev) ShortestPathWithPrev(Graph graph, int source)
        {
            var dist = new Dictionary<int, double>();
            var prev = new Dictionary<int, int>();
            var pq = new SortedSet<(double, int)>();

            foreach (var node in graph.AdjList.Keys)
            {
                dist[node] = double.MaxValue;
                prev[node] = -1;
            }

            dist[source] = 0;
            pq.Add((0, source));

            while (pq.Count > 0)
            {
                var (currentDist, u) = pq.Min;
                pq.Remove(pq.Min);

                foreach (var (v, weight) in graph.AdjList[u])
                {
                    if (dist[u] + weight < dist[v])
                    {
                        pq.Remove((dist[v], v));
                        dist[v] = dist[u] + weight;
                        prev[v] = u;
                        pq.Add((dist[v], v));
                    }
                }
            }
            return (dist, prev);
        }

        // Reconstruct path from source to target
        public static List<int> GetPath(Dictionary<int, int> prev, int target)
        {
            var path = new List<int>();
            int current = target;
            while (current != -1)
            {
                path.Add(current);
                current = prev[current];
            }
            path.Reverse();
            return path;
        }
    }
}
