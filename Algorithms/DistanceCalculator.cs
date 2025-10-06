using RideSphere.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideSphere.Algorithms
{
    public static class DistanceCalculator
    {
        public static double Haversine(Location a, Location b)
        {
            double R = 6371;
            double dLat = (b.Latitude - a.Latitude) * Math.PI / 180;
            double dLon = (b.Longitude - a.Longitude) * Math.PI / 180;
            double lat1 = a.Latitude * Math.PI / 180;
            double lat2 = b.Latitude * Math.PI / 180;

            double h = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(lat1) * Math.Cos(lat2) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(h), Math.Sqrt(1 - h));

            return R * c; // km
        }
    }
}
