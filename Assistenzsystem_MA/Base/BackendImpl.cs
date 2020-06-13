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

            Anleitungszustand.OnAnleitungSet += Schrittdatenbank.setCurrentAnleitung;
            Anleitungszustand.OnAnleitungsschrittChanged += Medienfilter.ensureFilterIsOn;
            Anleitungszustand.OnAnleitungsschrittChanged += Medienfilter.filterAnleitungsschritt;
            Anleitungszustand.OnAnleitungsschrittChanged += Schrittdatenbank.setCurrentAnleitungsschritt;
            Anleitungszustand.OnAnleitungsschrittFinished += Schrittdatenbank.trySubmitCurrentStep;
            Anleitungszustand.OnAnleitungUnloaded += alertUnload;
            Anleitungszustand.OnAnleitungUnloaded += Schrittdatenbank.resetCurrentStep;

            Medienfilter.OnFilteredSchritt += broadcastSchrittMedia;
            Medienfilter.Mitarbeiterdatenbank.OnChangedMitarbeiter += Schrittdatenbank.setCurrentMitarbeiter;

            Schrittdatenbank.OnUpdatedSchrittbearbeitungsinfos += Medienfilter.adjustMitarbeiterSkill;

            Bilderkennung.OnWrong += Schrittdatenbank.incrementVersuchszahl;
            Bilderkennung.OnWrong += Medienfilter.incrementVersuchszahl;
            Bilderkennung.OnWrong += Anleitungszustand.reloadStep;
            Bilderkennung.OnRight += Anleitungszustand.flipForward;
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
            Bilderkennung.recognizeImageAsRight();
        }

        public void recognizeImageAsWrong()
        {
            Bilderkennung.recognizeImageAsWrong();
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
            foreach (var mediumWithInfos in e.FilteredAnleitungsschritt.AnleitungsmediaWithInfos)
            {
                OnSendingMedia?.Invoke(this, new MediaArgs(mediumWithInfos.Anleitungsmedium));
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
