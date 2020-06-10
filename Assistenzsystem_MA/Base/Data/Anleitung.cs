using System.Collections.Generic;

namespace Assistenzsystem_MA.Base.Data
{
    public class Anleitung
    {
        public string Name { get; set; }
        public List<Anleitungsschritt> Anleitungsschritts { get; set; }
        public int Schrittzahl
        {
            get
            {
                return Anleitungsschritts.Count;
            }
        }

        public Anleitung()
        {

        }

        public Anleitung(string name, List<Anleitungsschritt> anleitungsschritts)
        {
            Name = name;
            Anleitungsschritts = anleitungsschritts;
        }

        public override string ToString()
        {
            return Name+"("+Anleitungsschritts.Count+" Steps)";
        }

    }
}
