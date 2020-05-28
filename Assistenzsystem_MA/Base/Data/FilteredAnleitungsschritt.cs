namespace Assistenzsystem_MA.Base.Data
{
    using System.Collections.Generic;

    class FilteredAnleitungsschritt : Anleitungsschritt
    {

        public FilteredAnleitungsschritt(string name, List<Anleitungsmedium> anleitungsmedia) : base(name, anleitungsmedia)
        {

        }

    }
}
