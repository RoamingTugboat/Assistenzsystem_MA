﻿namespace Assistenzsystem_MA
{
    class TextOnlyStrategy : FilterStrategy
    {
        public override FilteredAnleitungsschritt filter(Anleitungsschritt anleitungsschritt)
        {
            // Filter out any Media that aren't Text2D objects:
            anleitungsschritt.Anleitungsmedia.RemoveAll(medium => !(medium is Text2D));
            return new FilteredAnleitungsschritt(anleitungsschritt.Name, anleitungsschritt.Anleitungsmedia);
        }
    }
}
