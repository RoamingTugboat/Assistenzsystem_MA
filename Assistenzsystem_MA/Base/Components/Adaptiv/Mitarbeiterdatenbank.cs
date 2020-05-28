using Assistenzsystem_MA.Base.Data;
using System.Collections.Generic;

namespace Assistenzsystem_MA.Base.Components.Adaptiv
{
    class Mitarbeiterdatenbank
    {
        List<Mitarbeiter> Mitarbeiters;

        public Mitarbeiterdatenbank(List<Mitarbeiter> mitarbeiters)
        {
            Mitarbeiters = mitarbeiters;
        }
    }
}
