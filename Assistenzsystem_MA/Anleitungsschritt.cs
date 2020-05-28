using System;
using System.Collections.Generic;

namespace Assistenzsystem_MA
{
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
