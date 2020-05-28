using System;
using System.Collections.Generic;

namespace Assistenzsystem_MA
{
    class Medienfilter
    {
        public EventHandler<FilteredSchrittArgs> OnFilteredSchritt;

        Mitarbeiterdatenbank Mitarbeiterdatenbank { get; set; }
        FilterStrategy FilterStrategy { get; set; }

        public Medienfilter()
        {
            
            Mitarbeiterdatenbank = generateDefaultDatenbank();
            FilterStrategy = new TextOnlyStrategy();

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
            filter(e.Anleitungsschritt);
        }

        void filter(Anleitungsschritt anleitungsschritt)
        {
            var filteredSchritt = FilterStrategy.filter(anleitungsschritt);
            OnFilteredSchritt.Invoke(this, new FilteredSchrittArgs(filteredSchritt));
        }

    }
}
