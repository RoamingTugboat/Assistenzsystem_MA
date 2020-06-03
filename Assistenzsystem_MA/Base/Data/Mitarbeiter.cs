using System;
using Assistenzsystem_MA.Base.Data;

namespace Assistenzsystem_MA.Base.Data
{
    class Mitarbeiter
    {
        public string Name { get; private set; }
        public Mitarbeiterinformationen Mitarbeiterinformationen { get; private set; }

        public Mitarbeiter(string name)
        {
            Name = name;
            Mitarbeiterinformationen = new Mitarbeiterinformationen();
        }

    }
}
