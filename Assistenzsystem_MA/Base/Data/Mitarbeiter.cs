using System;
using Assistenzsystem_MA.Base.Data;

namespace Assistenzsystem_MA.Base.Data
{
    public class Mitarbeiter
    {
        public string Name { get; set; }
        public Mitarbeiterinformationen Mitarbeiterinformationen { get; set; }

        public Mitarbeiter()
        {

        }
        public Mitarbeiter(string name)
        {
            Name = name;
            Mitarbeiterinformationen = new Mitarbeiterinformationen();
        }

        public override string ToString()
        {
            return Name + "("+Mitarbeiterinformationen+")";
        }
    }
}
