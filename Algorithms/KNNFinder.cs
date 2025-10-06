using RideSphere.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideSphere.Algorithms
{
    public class KNNFinder
    {
        public static List<Driver> FindNearestDrivers(List<Driver> drivers, Location riderLocation, int k)
        {
            var available = drivers.Where(d => d.IsAvailable).ToList();
            return available
                .Select(d => new
                {
                    Driver = d,
                    Distance = DistanceCalculator.Haversine(d.CurrentLocation, riderLocation)
                })
                .OrderBy(x => x.Distance)
                .Take(k)
                .Select(x => x.Driver)
                .ToList();
        }
    }
}
