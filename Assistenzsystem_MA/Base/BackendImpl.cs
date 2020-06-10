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
        Schrittdatenbank Schrittdatenbank;
        Bilderkennung Bilderkennung;

        public BackendImpl()
        {
            Anleitungszustand = new Anleitungszustand();
            Medienfilter = new Medienfilter();
            Schrittdatenbank = new Schrittdatenbank();
            Bilderkennung = new Bilderkennung();

            // Logic
            Anleitungszustand.OnAnleitungsschrittChanged += Medienfilter.receiveSchritt;
            Medienfilter.OnFilteredSchritt += broadcastSchrittMedia;
            Bilderkennung.OnWrong += Schrittdatenbank.incrementVersuchszahl;
            Bilderkennung.OnRight += Anleitungszustand.flipForward;
            Anleitungszustand.OnAnleitungUnloaded += alertUnload;

            // Schrittinfo
            Medienfilter.Mitarbeiterdatenbank.OnChangedMitarbeiter += Schrittdatenbank.setCurrentMitarbeiter;
            Anleitungszustand.OnAnleitungSet += Schrittdatenbank.setCurrentAnleitung;
            Anleitungszustand.OnAnleitungsschrittChanged += Schrittdatenbank.setCurrentAnleitungsschritt;
        }

        public void changeAnleitung(string newAnleitungName)
        {
            Anleitungszustand.changeAnleitung(newAnleitungName);
        }

        public void changeMitarbeiter(string newMitarbeiterName)
        {
            Medienfilter.Mitarbeiterdatenbank.changeMitarbeiter(newMitarbeiterName);
        }

        public void recognizeImageAsRight()
        {
            Schrittdatenbank.submitStep();
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

        public void alertUnload(object sender, AnleitungArgs e)
        {
            Console.WriteLine("Anleitung "+e.Anleitung.Name+" wurde entfernt, bitte mit cha neue Anleitung setzen.");
        }

        public void saveSchrittdatenbank()
        {
            Schrittdatenbank.saveToFile("schrittdaten.xml");
            Console.WriteLine("Saved schrittdaten");
        }

        public void loadSchrittdatenbank()
        {
            Schrittdatenbank.loadFromFile("schrittdaten.xml");
            Console.WriteLine("Loaded schrittdaten");
        }

        public void printSchrittdatenbank()
        {
            Schrittdatenbank.print();
        }
    }
}
