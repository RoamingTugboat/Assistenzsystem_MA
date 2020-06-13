using System.Collections.Generic;

namespace Assistenzsystem_MA.Base.Data
{
    public class Anleitungsschritt
    {
        public string Name { get; set; }
        public List<MediumWithInfos> AnleitungsmediaWithInfos { get; set; }

        public Anleitungsschritt()
        {
            AnleitungsmediaWithInfos = new List<MediumWithInfos>();
        }

        public Anleitungsschritt(string name, List<MediumWithInfos> medialistWithInfos)
        {
            Name = name;
            AnleitungsmediaWithInfos = medialistWithInfos;
        }

        public override string ToString()
        {
            var s = "Anleitungsschritt \"" + Name + "\":";
            foreach(var medium in AnleitungsmediaWithInfos)
            {
                s += " ";
                s += medium.Anleitungsmedium.GetType().Name;   
            }
            return s;
        }

        public Anleitungsschritt Copy()
        {
            // MA: Clones sind kein triviales problem. Siehe https://stackoverflow.com/questions/1308803/why-is-cloning-in-net-so-difficult/1308868#1308868
            var clone = new Anleitungsschritt();
            clone.Name = this.Name; // Diese kopie ist trivial, weil sie nur einen string kopiert
            foreach(var stepversion in this.AnleitungsmediaWithInfos) 
            {
                // Diese kopie nicht, weil die listenelemente referenzen sind die einzeln geklont werden muessen:
                clone.AnleitungsmediaWithInfos.Add(stepversion.Copy());
            }
            return clone;
        }

    }
}
