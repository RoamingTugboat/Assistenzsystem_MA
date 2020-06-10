namespace Assistenzsystem_MA.Base.Data
{
    public abstract class Anleitungsmedium
    {
        public Assistenzinformationen Assistenzinformationen { get; set; }

        public Anleitungsmedium()
        {
            Assistenzinformationen = new Assistenzinformationen();
        }
    }
}
