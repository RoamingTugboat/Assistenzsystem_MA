namespace Assistenzsystem_MA.Base.Data
{
    public class Mitarbeiter
    {
        public string Name { get; set; }
        public Assistenzinformationen Assistenzinformationen { get; set; }

        public Mitarbeiter()
        {

        }
        public Mitarbeiter(string name)
        {
            Name = name;
            Assistenzinformationen = new Assistenzinformationen();
        }

        public Mitarbeiter(string name, Assistenzinformationen assistenzinformationen)
        {
            Name = name;
            Assistenzinformationen = assistenzinformationen;
        }

        public override string ToString()
        {
            return Name + "("+Assistenzinformationen+")";
        }
    }
}
