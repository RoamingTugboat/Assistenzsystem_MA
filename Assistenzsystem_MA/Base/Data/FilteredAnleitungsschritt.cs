using System.Collections.Generic;

namespace Assistenzsystem_MA.Base.Data
{
    public class FilteredAnleitungsschritt : Anleitungsschritt
    {
        public FilteredAnleitungsschritt()
        {

        }

        public FilteredAnleitungsschritt(Anleitungsschritt anleitungsschritt) : base(anleitungsschritt.Name, anleitungsschritt.Anleitungsmedia, anleitungsschritt.Assistenzinformationen)
        {

        }

        public FilteredAnleitungsschritt(string name, List<Anleitungsmedium> anleitungsmedia, Assistenzinformationen assistenzinformationen) : base(name, anleitungsmedia, assistenzinformationen)
        {

        }

    }
}
