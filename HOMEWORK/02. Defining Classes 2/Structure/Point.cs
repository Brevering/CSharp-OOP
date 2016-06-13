namespace Structure
{
    using System;
    using System.Linq;

    public struct Point3D
    {
        private static readonly Point3D pointO = new Point3D(0, 0, 0);

        public Point3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public override string ToString()
        {
            return string.Format("Point: {0}, {1}, {2}", this.X, this.Y, this.Z);
        }

        public static Point3D O
        {
            get
            {
                return pointO;
            }
        }

        public static Point3D Parse(string text)
        {
            int removeColon = text.IndexOf(':');
            double[] coordinates = text
                .Substring(removeColon + 1, text.Length - removeColon - 1)
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => double.Parse(x))
                .ToArray();

            return new Point3D() { X = coordinates[0], Y = coordinates[1], Z = coordinates[2] };
        }
    }
}
