using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideSphere.Models
{
    public class Rider
    {
        public string Name { get; }
        public Location Pickup { get; }
        public Location Drop { get; }

        public Rider(string name, Location pickup, Location drop)
        {
            Name = name;
            Pickup = pickup;
            Drop = drop;
        }
    }
}
