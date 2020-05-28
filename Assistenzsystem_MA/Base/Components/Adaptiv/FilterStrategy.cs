using Assistenzsystem_MA.Base.Data;

namespace Assistenzsystem_MA.Base.Components.Adaptiv
{
    abstract class FilterStrategy
    {
        public FilterStrategy()
        {

        }

        public abstract FilteredAnleitungsschritt filter(Anleitungsschritt anleitungsschritt);
    }
}
