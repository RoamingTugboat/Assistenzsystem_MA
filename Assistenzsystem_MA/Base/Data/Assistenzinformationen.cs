using System;

namespace Assistenzsystem_MA.Base.Data
{
    public class Assistenzinformationen
    {
        // Level 0 ist niedrigster assistenzgrad, level 5 hoechster assistenzgrad.
        // Medien auf level 0 sollen immer angezeigt werden, die hoeheren level nur wenn der mitarbeiter entsprechend schlecht ist.
        // Mitarbeiter auf level 0 sind super gut, mitarbeiter auf level 5 brauchen viel hilfe.
        int assistenzlevel;
        public int Assistenzlevel
        {
            get
            {
                return assistenzlevel;
            }
            set
            {
                if (0 <= value && value <= 5)
                {
                    assistenzlevel = value;
                }
                else
                {
                    Console.WriteLine("Kann Assistenzlevel nicht aendern, da es schon auf "+assistenzlevel+" ist.");
                }
            }
        }
        public Assistenzinformationen()
        {
            Assistenzlevel = 0;
        }
        public Assistenzinformationen(int assistenzlevel)
        {
            Assistenzlevel = assistenzlevel;
        }

        public override string ToString()
        {
            return "Assistenzlevel:"+Assistenzlevel;
        }

    }
}
