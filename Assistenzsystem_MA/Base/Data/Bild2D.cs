namespace Assistenzsystem_MA.Base.Data
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
