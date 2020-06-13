using System.Collections.Generic;

namespace Assistenzsystem_MA.Base.Data
{
    public class MediumWithInfos
    {
        public Anleitungsmedium Anleitungsmedium { get; set; }
        public Assistenzinformationen Assistenzinformationen { get; set; }

        public MediumWithInfos()
        {

        }

        public MediumWithInfos(Anleitungsmedium anleitungsmedium, Assistenzinformationen assistenzinformationen)
        {
            Anleitungsmedium = anleitungsmedium;
            Assistenzinformationen = assistenzinformationen;
        }

        public override string ToString()
        {
            return "Medialist with " + Anleitungsmedium.GetType().Name + "(" + Assistenzinformationen.ToString()+")";
        }

        public MediumWithInfos Copy()
        {
            // MA: Clones sind kein triviales problem. Siehe https://stackoverflow.com/questions/1308803/why-is-cloning-in-net-so-difficult/1308868#1308868
            // diese Kopie ist problematisch, da sie zwar eine neue Liste anlegt, aber die Referenzen in dieser Liste zeigen dennoch auf die selben objekte wie die ursprungsliste. Fuer unseren Anwendungsfall (Referenzen aus der Liste loeschen) fuehrt das zu keinen Problemen, aber ist dennoch nicht sicher. Im Zusammenhang mit diesen Kopieproblemen wird die immutability von Objekten interessant, da readonly-flags zumindest manche moeglichen Probleme verhindern koennen.
            var clone = new MediumWithInfos();
            clone.Anleitungsmedium = Anleitungsmedium;
            clone.Assistenzinformationen = Assistenzinformationen;
            return clone;
        }

    }
}
