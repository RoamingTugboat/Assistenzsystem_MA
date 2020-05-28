using System;

namespace Assistenzsystem_MA 
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
