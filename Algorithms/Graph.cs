using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideSphere.Algorithms
{
    public class Graph
    {
        public Dictionary<int, List<(int, double)>> AdjList { get; }

        public Graph()
        {
            AdjList = new Dictionary<int, List<(int, double)>>();
        }

        public void AddEdge(int from, int to, double distance)
        {
            if (!AdjList.ContainsKey(from))
                AdjList[from] = new List<(int, double)>();
            if (!AdjList.ContainsKey(to))
                AdjList[to] = new List<(int, double)>();

            AdjList[from].Add((to, distance));
            AdjList[to].Add((from, distance));
        }
    }
}
