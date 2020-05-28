namespace Assistenzsystem_MA
{
    abstract class FilterStrategy
    {
        public FilterStrategy()
        {
            
        }

        public abstract FilteredAnleitungsschritt filter(Anleitungsschritt anleitungsschritt);
    }
}
