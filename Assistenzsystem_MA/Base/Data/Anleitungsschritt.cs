using System.Collections.Generic;

namespace Assistenzsystem_MA.Base.Data
{
    class Anleitungsschritt
    {
        public string Name { get; private set; }
        public List<Anleitungsmedium> Anleitungsmedia;
        public Assistenzinformationen Assistenzinformationen { get; private set; }

        public Anleitungsschritt(string name, List<Anleitungsmedium> anleitungsmedia)
        {
            Name = name;
            Anleitungsmedia = anleitungsmedia;
        }

    }
}
