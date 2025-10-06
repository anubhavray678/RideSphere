using RideSphere.Models;

namespace RideSphere.Algorithms
{
    public static class FareCalculator
    {
        public static double CalculateFare(double distanceKm, VehicleType vehicleType, double surgeFactor)
        {
            double baseFare = vehicleType switch
            {
                VehicleType.Bike => 30 + distanceKm * 8,
                VehicleType.Sedan => 50 + distanceKm * 10,
                VehicleType.SUV => 80 + distanceKm * 15,
                _ => 50 + distanceKm * 10
            };
            return baseFare * surgeFactor;
        }
    }
}
