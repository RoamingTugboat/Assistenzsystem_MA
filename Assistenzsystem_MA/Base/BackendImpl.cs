using Assistenzsystem_MA.Base.Args;
using Assistenzsystem_MA.Base.Components.Adaptiv;
using Assistenzsystem_MA.Base.Components.Anleitungen;
using Assistenzsystem_MA.Base.Components.Kamera;
using System;

namespace Assistenzsystem_MA.Base
{
    class BackendImpl
    {
        /// <summary>
        ///  Fired when new media are about to be sent. Use this to delete your active media before new ones arrive.
        /// </summary>
        public EventHandler<EventArgs> OnAboutToSendNewMedia;

        /// <summary>
        /// Fired multiple when an new assembly step is loaded. Media are e.g. 2D-Text, 3D-Models, images, or positioned images. The media explain the assembly step.
        /// </summary>
        public EventHandler<MediaArgs> OnSendingMedium;

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

            // Possible improvement: Ask Anleitungszustand to emit a page instead of emissions being contingent on page flips
            Anleitungszustand.OnAnleitungSet += Schrittdatenbank.setCurrentAnleitung;
            Anleitungszustand.OnAnleitungsschrittChanged += Medienfilter.filterAnleitungsschritt;
            Anleitungszustand.OnAnleitungsschrittChanged += Schrittdatenbank.setCurrentAnleitungsschritt;
            Anleitungszustand.OnAnleitungUnloaded += alertUnload;
            Anleitungszustand.OnAnleitungUnloaded += Schrittdatenbank.resetCurrentStep;

            Medienfilter.OnFilteredSchritt += broadcastSchrittMedia;
            Medienfilter.Mitarbeiterdatenbank.OnChangedMitarbeiter += Schrittdatenbank.setCurrentMitarbeiter;

            Bilderkennung.OnWrong += Schrittdatenbank.trySubmitCurrentStepWrong;
            Bilderkennung.OnWrong += Anleitungszustand.reloadStep;
            Bilderkennung.OnRight += Schrittdatenbank.trySubmitCurrentStepRight;
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
            OnAboutToSendNewMedia?.Invoke(this, new EventArgs());
            foreach (var mediumWithInfos in e.FilteredAnleitungsschritt.AnleitungsmediaWithInfos)
            {
                OnSendingMedium?.Invoke(this, new MediaArgs(mediumWithInfos.Anleitungsmedium));
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
