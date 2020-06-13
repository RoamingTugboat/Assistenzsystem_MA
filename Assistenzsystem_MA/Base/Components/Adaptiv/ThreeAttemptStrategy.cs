using Assistenzsystem_MA.Base.Data;
using System;

namespace Assistenzsystem_MA.Base.Components.Adaptiv
{
    class ThreeAttemptStrategy : FilterStrategy
    {
        Anleitungsschritt mostRecentAnleitungsschritt;
        int SameSchrittAttempts = 0;
        public override FilteredAnleitungsschritt filter(Anleitungsschritt anleitungsschritt, Assistenzinformationen mitarbeiterInfos)
        {
            // Keep track of how many times an assembly worker has worked on the same step in a row:
            if(mostRecentAnleitungsschritt == null)
            {
                mostRecentAnleitungsschritt = anleitungsschritt;
                SameSchrittAttempts = 0;
            }
            else
            {
                if(mostRecentAnleitungsschritt.Equals(anleitungsschritt))
                {
                    SameSchrittAttempts++;
                }
                else
                {
                    mostRecentAnleitungsschritt = anleitungsschritt;
                    // If new step was triggered without repeated attempts, assembly worker must be getting better:
                    if(SameSchrittAttempts == 0)
                    {
                        mitarbeiterInfos.Assistenzlevel--;
                        Console.WriteLine("Mitarbeiter got it right on the first try, their Assistenzlevel is now " + mitarbeiterInfos.Assistenzlevel);
                    }
                    else
                    {
                        SameSchrittAttempts = 0;
                    }
                }
            }

            // If mitarbeiter worked on the same step three times, they need more assistance 
            if (SameSchrittAttempts > 0 && SameSchrittAttempts % 3 == 0)
            {
                mitarbeiterInfos.Assistenzlevel++;
                Console.WriteLine("Mitarbeiter made 3 wrong attempts, their Assistenzlevel is now " + mitarbeiterInfos.Assistenzlevel);
            }
            
            // Finally, filter step based on Erfahrungsgrad:
            var filteredSchritt = new FilteredAnleitungsschritt(anleitungsschritt.Copy());
            filteredSchritt.AnleitungsmediaWithInfos.RemoveAll(stepversion => (stepversion.Assistenzinformationen.Assistenzlevel) > mitarbeiterInfos.Assistenzlevel);
            return filteredSchritt;
        }

        public void incrementAttempts()
        {
            SameSchrittAttempts++;
        }
    }
}
