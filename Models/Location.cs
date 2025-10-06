using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideSphere.Models
{
    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int NodeId { get; set; } 

        public Location(double lat, double lon, int nodeId = -1)
        {
            Latitude = lat;
            Longitude = lon;
            NodeId = nodeId;
        }
    }

}
