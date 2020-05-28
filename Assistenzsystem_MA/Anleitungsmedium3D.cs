namespace Assistenzsystem_MA
{
    abstract class Anleitungsmedium3D : Anleitungsmedium
    {
        public Point3D Position { get; private set; }
        public Point3D Orientation { get; private set; }

        protected Anleitungsmedium3D(Point3D position, Point3D orientation)
        {
            Position = position;
            Orientation = orientation;
        }

    }
}
