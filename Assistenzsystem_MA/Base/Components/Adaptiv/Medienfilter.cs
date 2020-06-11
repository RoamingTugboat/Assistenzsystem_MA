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
        public Mitarbeiterinformationen CurrentMitarbeiterinfos { get; set; }
        FilterStrategy FilterStrategy { get; set; }

        public Medienfilter()
        {
            Mitarbeiterdatenbank = generateDefaultDatenbank();
            FilterStrategy = new PassAllStrategy();
            // We need this so we can adjust the Filter to the active Mitarbeiter, e.g. bad Mitarbeiters need
            // a more lenient Filter and good Mitarbeiters can have everything filtered away:
            Mitarbeiterdatenbank.OnChangedMitarbeiter += refreshMitarbeiterInfos;
        }

        Mitarbeiterdatenbank generateDefaultDatenbank()
        {
            return new Mitarbeiterdatenbank(new List<Mitarbeiter>() {
                new Mitarbeiter("Jake"),
                new Mitarbeiter("Ari")
            });
        }

        public void filterAnleitungsschritt(object sender, AnleitungsschrittArgs e)
        {
            var filteredSchritt = FilterStrategy.filter(e.Anleitungsschritt);
            OnFilteredSchritt.Invoke(this, new FilteredSchrittArgs(filteredSchritt));
        }

        void refreshMitarbeiterInfos(object sender, MitarbeiterArgs e)
        {
            this.CurrentMitarbeiterinfos = e.Mitarbeiter.Mitarbeiterinformationen;
        }
    }
}
