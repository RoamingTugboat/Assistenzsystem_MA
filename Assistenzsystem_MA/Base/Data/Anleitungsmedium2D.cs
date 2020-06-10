namespace Assistenzsystem_MA.Base.Data
{
    public abstract class Anleitungsmedium2D : Anleitungsmedium
    {
        public Point2D Position { get; set; }

        public Anleitungsmedium2D()
        {

        }

        public Anleitungsmedium2D(Point2D position)
        {
            Position = position;
        }

    }
}
