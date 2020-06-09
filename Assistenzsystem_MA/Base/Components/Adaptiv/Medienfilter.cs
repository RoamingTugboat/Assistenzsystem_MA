using Assistenzsystem_MA.Base.Args;
using Assistenzsystem_MA.Base.Data;
using System;
using System.Collections.Generic;

namespace Assistenzsystem_MA.Base.Components.Adaptiv
{

    class Medienfilter
    {
        public EventHandler<FilteredSchrittArgs> OnFilteredSchritt;
        public Mitarbeiterdatenbank Mitarbeiterdatenbank { get; set; }
        FilterStrategy FilterStrategy { get; set; }

        public Medienfilter()
        {

            Mitarbeiterdatenbank = generateDefaultDatenbank();
            FilterStrategy = new TextOnlyStrategy();

        }

        Mitarbeiterdatenbank generateDefaultDatenbank()
        {
            return new Mitarbeiterdatenbank(new List<Mitarbeiter>() {
                new Mitarbeiter("Jake"),
                new Mitarbeiter("Ari")
            });
        }

        public void receiveSchritt(object sender, AnleitungsschrittArgs e)
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
