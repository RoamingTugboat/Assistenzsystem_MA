namespace Assistenzsystem_MA.Base.Data
{
    public abstract class Anleitungsmedium3D : Anleitungsmedium
    {
        public Point3D Position { get; set; }
        public Point3D Orientation { get; set; }

        protected Anleitungsmedium3D(Point3D position, Point3D orientation)
        {
            Position = position;
            Orientation = orientation;
        }

    }
}
