namespace Assistenzsystem_MA
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
