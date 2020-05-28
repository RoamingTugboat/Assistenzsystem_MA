using Assistenzsystem_MA.Base.Args;
using Assistenzsystem_MA.Base.Components.Adaptiv;
using Assistenzsystem_MA.Base.Components.Anleitungen;
using System;

namespace Assistenzsystem_MA.Base
{
    class BackendImpl
    {
        public EventHandler<MediaArgs> OnSendingMedia;

        Medienfilter Medienfilter;
        Anleitungszustand Anleitungszustand;

        public BackendImpl()
        {
            Anleitungszustand = new Anleitungszustand();
            Medienfilter = new Medienfilter();
            Anleitungszustand.OnSchrittChanged += Medienfilter.receiveSchritt;
            Medienfilter.OnFilteredSchritt += broadcastSchrittMedia;
            Anleitungszustand.changeAnleitung("Lamellenkupplung");
        }

        public void changeAnleitung(string newAnleitungName)
        {
            Anleitungszustand.changeAnleitung(newAnleitungName);
        }

        public void flipForward()
        {
            Anleitungszustand.flipForward();
        }

        public void flipBackward()
        {
            Anleitungszustand.flipBackward();
        }

        void broadcastSchrittMedia(object sender, FilteredSchrittArgs e)
        {
            foreach (var medium in e.FilteredAnleitungsschritt.Anleitungsmedia)
            {
                OnSendingMedia?.Invoke(this, new MediaArgs(medium));
            }
        }

        public void listAnleitungen()
        {
            foreach (var anleitung in Anleitungszustand.Anleitungsdatenbank)
            {
                Console.WriteLine(anleitung.Name);
            }
        }


    }
}
