namespace Assistenzsystem_MA.Base.Data
{
    using System.Collections.Generic;
    class Anleitungsschritt
    {
        public string Name { get; private set; }
        public List<Anleitungsmedium> Anleitungsmedia;

        public Anleitungsschritt(string name, List<Anleitungsmedium> anleitungsmedia)
        {
            Name = name;
            Anleitungsmedia = anleitungsmedia;
        }

    }
}
