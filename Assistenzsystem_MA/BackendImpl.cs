using System;

namespace Assistenzsystem_MA
{
    class BackendImpl
    {
        public Medienfilter medienfilter { get; private set; }
        public Anleitungszustand anleitungszustand { get; private set; }

        public BackendImpl()
        {
            medienfilter = new Medienfilter();
            anleitungszustand = new Anleitungszustand();

            anleitungszustand.OnSchrittChanged += medienfilter.receiveSchritt;
        }

        public void listAnleitungen()
        {
            foreach (var anleitung in anleitungszustand.Anleitungen)
            {
                Console.WriteLine(anleitung.Name);
            }
        }
    }
}
