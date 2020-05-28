namespace Assistenzsystem_MA.Base.Data
{
    abstract class Anleitungsmedium
    {
        public Assistenzinformationen Assistenzinformationen { get; private set; }

        public Anleitungsmedium()
        {
            Assistenzinformationen = new Assistenzinformationen();
        }
    }
}
