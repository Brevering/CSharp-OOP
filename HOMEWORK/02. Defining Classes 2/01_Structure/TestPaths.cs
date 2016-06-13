namespace Structure
{
    using System;
    class TestPaths
    {
        static void Main()
        {
            Point3D point = new Point3D() { X = 1, Y = 2, Z = 3 };

            Console.WriteLine(point);
            Console.WriteLine(Point3D.O);

            var dist = Distance.CalculateDistanceTwoPoints3D(point, Point3D.O);
            Console.WriteLine(dist);

            var path = new Path();

            for (int i = 0; i < 10; i++)
            {
                path.AddPoint(new Point3D() { X = i, Y = i * 2, Z = i + 3 });
            }

            var pathString = "../../path.txt";

            PathStorage.SavePath(path, pathString);

            var pathFromFile = PathStorage.LoadPath(pathString);

            foreach (var p in pathFromFile)
            {
                Console.WriteLine(p);
            }
        }
    }
}
