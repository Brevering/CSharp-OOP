namespace Structure
{
    using System.Collections;
    using System.Collections.Generic;

    public class Path : IEnumerable<Point3D>
    {
        private ICollection<Point3D> points;

        public Path()
        {
            this.points = new List<Point3D>();
        }

        public void AddPoint(Point3D point)
        {
            this.points.Add(point);
        }

        public IEnumerator<Point3D> GetEnumerator()
        {
            return this.points.GetEnumerator();
        }

        public void RemovePoint(Point3D point)
        {
            this.points.Remove(point);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
