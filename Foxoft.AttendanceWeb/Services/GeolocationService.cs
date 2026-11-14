using System;

namespace Foxoft.AttendanceWeb.Services
{
    public interface IGeolocationService
    {
        double CalculateDistanceMeters(double lat1, double lon1, double lat2, double lon2);
        bool ValidateLocation(double currentLat, double currentLon, double targetLat, double targetLon, double radiusMeters, out double distance);
    }

    public class GeolocationService : IGeolocationService
    {
        private const double EarthRadiusMeters = 6371000.0;

        public double CalculateDistanceMeters(double lat1, double lon1, double lat2, double lon2)
        {
            double dLat = ToRadians(lat2 - lat1);
            double dLon = ToRadians(lon2 - lon1);

            double rLat1 = ToRadians(lat1);
            double rLat2 = ToRadians(lat2);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(rLat1) * Math.Cos(rLat2) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return EarthRadiusMeters * c;
        }

        public bool ValidateLocation(double currentLat, double currentLon, double targetLat, double targetLon, double radiusMeters, out double distance)
        {
            distance = CalculateDistanceMeters(currentLat, currentLon, targetLat, targetLon);
            return distance <= radiusMeters;
        }

        private static double ToRadians(double degrees)
        {
            return degrees * (Math.PI / 180.0);
        }
    }
}
