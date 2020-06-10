using System.Collections.Generic;

namespace Assistenzsystem_MA.Base.Data
{
    public class Anleitungsschritt
    {
        public string Name { get; set; }
        public List<Anleitungsmedium> Anleitungsmedia { get; set; }
        public Assistenzinformationen Assistenzinformationen { get; set; }

        public Anleitungsschritt()
        {

        }

        public Anleitungsschritt(string name, List<Anleitungsmedium> anleitungsmedia)
        {
            Name = name;
            Anleitungsmedia = anleitungsmedia;
        }

        public override string ToString()
        {
            return Name + "("+Anleitungsmedia.Count+" Media)";
        }

    }
}
