using Assistenzsystem_MA.Base.Data;
using System.Linq;

namespace Assistenzsystem_MA.Base.Components.Adaptiv
{
    class Text2DOnlyStrategy : FilterStrategy
    {
        public override FilteredAnleitungsschritt filter(Anleitungsschritt anleitungsschritt, Assistenzinformationen mitarbeiterinfos)
        {
            // Filter out any Media that aren't Text2D objects:
            var filteredSchritt = new FilteredAnleitungsschritt(anleitungsschritt.Copy());
            filteredSchritt.AnleitungsmediaWithInfos.RemoveAll(medium => !(medium.Anleitungsmedium is Text2D));
            return filteredSchritt;
        }
    }
}
