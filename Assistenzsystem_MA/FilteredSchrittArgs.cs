using System;

namespace Assistenzsystem_MA 
{
    class FilteredSchrittArgs : EventArgs
    {
        FilteredAnleitungsschritt FilteredAnleitungsschritt;

        public FilteredSchrittArgs(FilteredAnleitungsschritt filteredAnleitungsschritt)
        {
            FilteredAnleitungsschritt = filteredAnleitungsschritt;
        }
    }
}
