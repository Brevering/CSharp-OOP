using System;

namespace Structure
{
    public static class Distance
    {
        public static double CalculateDistanceTwoPoints3D (Point3D a, Point3D b)
        {
            double result = Math.Sqrt(
               ((a.X - b.X) * (a.X - b.X)) +
               ((a.Y - b.Y) * (a.Y - b.Y)) +
               ((a.Z - b.Z) * (a.Z - b.Z)));
            return result;
        }
    }
}
