using Assistenzsystem_MA.Base.Data;

namespace Assistenzsystem_MA.Base.Components.Adaptiv
{
    abstract class FilterStrategy
    {
        
        protected bool Enabled { get; set; }

        public FilterStrategy()
        {

        }

        public void enable()
        {
            Enabled = true;
        }

        public void disable()
        {
            Enabled = false;
        }

        public abstract FilteredAnleitungsschritt filter(Anleitungsschritt anleitungsschritt, Mitarbeiterinformationen mitarbeiterinformationen);
    }
}
