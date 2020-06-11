using Assistenzsystem_MA.Base.Data;

namespace Assistenzsystem_MA.Base.Components.Adaptiv
{
    class PassAllStrategy : FilterStrategy
    {
        public override FilteredAnleitungsschritt filter(Anleitungsschritt anleitungsschritt)
        {
            // Just copy and pass on without filtering anything
            var filteredSchritt = new FilteredAnleitungsschritt(anleitungsschritt.Copy());
            return filteredSchritt;
        }
    }
}
