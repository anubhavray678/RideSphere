using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideSphere.Algorithms
{
    public static class Dijkstra
    {
        public static Dictionary<int, double> ShortestPath(Graph graph, int source)
        {
            var dist = new Dictionary<int, double>();
            var pq = new SortedSet<(double, int)>();

            foreach (var node in graph.AdjList.Keys)
                dist[node] = double.MaxValue;

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
                        pq.Add((dist[v], v));
                    }
                }
            }
            return dist;
        }
    }
}
