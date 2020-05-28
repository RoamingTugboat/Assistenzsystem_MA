using Assistenzsystem_MA.Base.Data;
using System;

namespace Assistenzsystem_MA.Base.Args
{
    class FilteredSchrittArgs : EventArgs
    {
        public FilteredAnleitungsschritt FilteredAnleitungsschritt { get; private set; }

        public FilteredSchrittArgs(FilteredAnleitungsschritt filteredAnleitungsschritt)
        {
            FilteredAnleitungsschritt = filteredAnleitungsschritt;
        }
    }
}
