using System;

namespace Assistenzsystem_MA.Base.Data
{
    class Mitarbeiter
    {
        public String Name { get; private set; }

        public Mitarbeiter(string name)
        {
            Name = name;
        }

    }
}
