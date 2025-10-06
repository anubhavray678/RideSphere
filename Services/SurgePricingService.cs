using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideSphere.Services
{
    public class SurgePricingService
    {
        private readonly Dictionary<string, (int riders, int drivers)> zoneData;

        public SurgePricingService()
        {
            zoneData = new Dictionary<string, (int, int)>();
        }

        public void UpdateZone(string zone, int riders, int drivers)
        {
            zoneData[zone] = (riders, drivers);
        }

        public double GetSurgeFactor(string zone)
        {
            if (!zoneData.ContainsKey(zone)) return 1.0;

            var (r, d) = zoneData[zone];
            if (d == 0) return 3.0; // extreme surge
            double ratio = (double)r / d;

            return Math.Min(1.0 + (ratio - 1) * 0.5, 3.0); // capped surge factor
        }
    }
}
