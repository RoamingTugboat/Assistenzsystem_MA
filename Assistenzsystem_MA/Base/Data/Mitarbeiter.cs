namespace Assistenzsystem_MA.Base.Data
{
    using System;
    class Mitarbeiter
    {
        public String Name { get; private set; }

        public Mitarbeiter(string name)
        {
            Name = name;
        }

    }
}
