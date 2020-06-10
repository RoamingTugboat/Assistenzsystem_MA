namespace Assistenzsystem_MA.Base.Data
{
    public class Bild2D : Anleitungsmedium2D
    {
        public string Path { get; set; }
        
        public Bild2D() : base()
        {

        }

        public Bild2D(Point2D position, string path) : base(position)
        {
            Path = path;
        }
    }
}
