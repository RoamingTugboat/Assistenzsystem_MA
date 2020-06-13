using Assistenzsystem_MA.Base.Args;
using Assistenzsystem_MA.Base.Data;
using System;
using System.Collections.Generic;

namespace Assistenzsystem_MA.Base.Components.Adaptiv
{
    class Mitarbeiterdatenbank
    {
        public EventHandler<MitarbeiterArgs> OnChangedMitarbeiter;

        List<Mitarbeiter> Mitarbeiters;
        Mitarbeiter activeMitarbeiter;

        public Mitarbeiterdatenbank(List<Mitarbeiter> mitarbeiters)
        {
            Mitarbeiters = mitarbeiters;
        }

        public void changeMitarbeiter(string newMitarbeiterName)
        {
            foreach (var mitarbeiter in this.Mitarbeiters)
            {
                if (mitarbeiter.Name.Equals(newMitarbeiterName))
                {
                    activeMitarbeiter = mitarbeiter;
                    Console.WriteLine("Mitarbeiter is now \"" + activeMitarbeiter.Name + "\".");
                    OnChangedMitarbeiter?.Invoke(this, new MitarbeiterArgs(mitarbeiter));
                    return;
                }
            }
            throw new Exception("Mitarbeiter mit diesem Namen existiert nicht: " + newMitarbeiterName);
        }
    }
}
