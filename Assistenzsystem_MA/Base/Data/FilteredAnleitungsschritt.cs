using System.Collections.Generic;

namespace Assistenzsystem_MA.Base.Data
{
    public class FilteredAnleitungsschritt : Anleitungsschritt
    {
        public FilteredAnleitungsschritt(string name, List<Anleitungsmedium> anleitungsmedia) : base(name, anleitungsmedia)
        {

        }

    }
}
