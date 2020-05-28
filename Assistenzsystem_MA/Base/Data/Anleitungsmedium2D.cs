namespace Assistenzsystem_MA.Base.Data
{
    abstract class Anleitungsmedium2D : Anleitungsmedium
    {
        public Point2D Position { get; private set; }

        public Anleitungsmedium2D(Point2D position)
        {
            Position = position;
        }

    }
}
