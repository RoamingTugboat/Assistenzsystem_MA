using System.Collections.Generic;

namespace Assistenzsystem_MA.Base.Data
{
    public class Anleitungsschritt
    {
        public string Name { get; set; }
        public List<Anleitungsmedium> Anleitungsmedia { get; set; }
        public Assistenzinformationen Assistenzinformationen { get; set; }

        public Anleitungsschritt()
        {

        }

        public Anleitungsschritt(string name, List<Anleitungsmedium> anleitungsmedia, Assistenzinformationen assistenzinformationen)
        {
            Name = name;
            Anleitungsmedia = anleitungsmedia;
            Assistenzinformationen = assistenzinformationen;
        }

        public override string ToString()
        {
            return Name + "("+Anleitungsmedia.Count+" Media)";
        }

        public Anleitungsschritt Copy()
        {
            // MA: Clones sind kein triviales problem. Siehe https://stackoverflow.com/questions/1308803/why-is-cloning-in-net-so-difficult/1308868#1308868
            var clone = new Anleitungsschritt();
            clone.Name = this.Name; // Diese kopie ist trivial, weil sie nur einen string kopiert

            var clonedAnleitungsmedia = new List<Anleitungsmedium>(); // diese Kopie ist problematisch, da sie zwar eine neue Liste anlegt, aber die Referenzen in dieser Liste zeigen dennoch auf die selben objekte wie die ursprungsliste. Fuer unseren Anwendungsfall (Referenzen aus der Liste loeschen) fuehrt das zu keinen Problemen, aber ist dennoch nicht sicher. Im Zusammenhang mit diesen Kopieproblemen wird die immutability von Objekten interessant, da readonly-flags zumindest manche moeglichen Probleme verhindern koennen.
            foreach(var medium in this.Anleitungsmedia)
            {
                clonedAnleitungsmedia.Add(medium);
            }
            clone.Anleitungsmedia = clonedAnleitungsmedia;

            clone.Assistenzinformationen = this.Assistenzinformationen;
            return clone;
        }

    }
}
