using Assistenzsystem_MA.Base.Data;

namespace Assistenzsystem_MA.Base.Components.Adaptiv
{
    class Text2DOnlyStrategy : FilterStrategy
    {
        public override FilteredAnleitungsschritt filter(Anleitungsschritt anleitungsschritt)
        {
            // Filter out any Media that aren't Text2D objects:
            var filteredSchritt = new FilteredAnleitungsschritt(anleitungsschritt.Copy());
            filteredSchritt.Anleitungsmedia.RemoveAll(medium => !(medium is Text2D));
            return filteredSchritt;
        }
    }
}
