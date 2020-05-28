namespace Assistenzsystem_MA
{
    class Bild2D : Anleitungsmedium2D
    {
        public string Path { get; private set; }
        public Bild2D(Point2D position, string path) : base(position)
        {
            Path = path;
        }
    }
}
