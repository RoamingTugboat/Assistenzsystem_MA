using System;
using System.Collections.Generic;

namespace Assistenzsystem_MA
{
    class Medienfilter
    {
        public EventHandler<FilteredSchrittArgs> OnFilteredSchritt;

        Mitarbeiterdatenbank Mitarbeiterdatenbank { get; private set; }
        public FilterStrategy FilterStrategy { get; private set; }

        public Medienfilter()
        {
            Mitarbeiterdatenbank = generateDefaultDatenbank();
            FilterStrategy = new FilterStrategy();
        }

        Mitarbeiterdatenbank generateDefaultDatenbank()
        {
            return new Mitarbeiterdatenbank(new List<Mitarbeiter>() {
                new Mitarbeiter("ens1dia"),
                new Mitarbeiter("Banderas"),
                new Mitarbeiter("-*postmann*-")
            });
        }

        public void receiveSchritt(object sender, SchrittChangedArgs e)
        {
            var schritt = e.Anleitungsschritt;



            OnFilteredSchritt.Invoke(this, new FilteredSchrittArgs(new FilteredAnleitungsschritt(e.Anleitungsschritt.Name, e.Anleitungsschritt.Anleitungsmedia)));
        }
    }
}
