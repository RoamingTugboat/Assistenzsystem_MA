namespace Assistenzsystem_MA.Base.Data
{
    class Assistenzinformationen
    {
        // Einfache:
        //   Medien, die zusammengehoeren (zB 2 Texte und ein Video fuer einen Schritt) haben einfach den selben wert,
        //   nur die 2 texte sind dann nochmal gecopypastet mit einem wert niedriger,
        //   und niedrigster UG mit nur einem text ist auch nochmal der text gecopypastet, dann mit 0.
        //   Also gibts halt duplicates, aber so ist es einfach. Der basicste text hier existiert dann zB 3 mal, einmal
        //   halt extra fuer jeden moeglichen UG in diesem Schritt.
        public int Schwierigkeitsgrad { get; set; }
        public Assistenzinformationen()
        {
            Schwierigkeitsgrad = 0;
        }

    }
}
