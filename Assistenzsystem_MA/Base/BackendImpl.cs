using Assistenzsystem_MA.Base.Args;
using Assistenzsystem_MA.Base.Components.Adaptiv;
using Assistenzsystem_MA.Base.Components.Anleitungen;
using Assistenzsystem_MA.Base.Components.Kamera;
using System;

namespace Assistenzsystem_MA.Base
{
    class BackendImpl
    {
        public EventHandler<MediaArgs> OnSendingMedia;

        Medienfilter Medienfilter;
        Anleitungszustand Anleitungszustand;
        Schritttracker Schritttracker;
        Bilderkennung Bilderkennung;

        public BackendImpl()
        {
            Anleitungszustand = new Anleitungszustand();
            Medienfilter = new Medienfilter();
            Schritttracker = new Schritttracker();
            Bilderkennung = new Bilderkennung();

            // Logic
            Anleitungszustand.OnAnleitungsschrittChanged += Medienfilter.receiveSchritt;
            Medienfilter.OnFilteredSchritt += broadcastSchrittMedia;

            // Schrittinfo
            Medienfilter.Mitarbeiterdatenbank.OnChangedMitarbeiter += Schritttracker.setCurrentMitarbeiter;
            Anleitungszustand.OnAnleitungChanged += Schritttracker.setCurrentAnleitung;
            Anleitungszustand.OnAnleitungsschrittChanged += Schritttracker.setCurrentAnleitungsschritt;
            Bilderkennung.OnWrong += Schritttracker.incrementVersuchszahl;
            Bilderkennung.OnRight += Schritttracker.submitStep;
            Bilderkennung.OnRight += Anleitungszustand.flipForward; // Careful: These last two steps need to happen in this order so the current step always knows its ZeitSekunden and then AFTERWARDS the manual flips forward, otherwise the Data will be incomplete
        }

        public void changeAnleitung(string newAnleitungName)
        {
            Anleitungszustand.changeAnleitung(newAnleitungName);
        }

        public void recognizeImageAsRight()
        {
            Bilderkennung.recognizeImageAsRight();
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
