using System;
using Assistenzsystem_MA.Base.Data;
using System.Collections.Generic;
using Assistenzsystem_MA.Base.Args;

namespace Assistenzsystem_MA.Base.Components.Adaptiv
{
    class Schritttracker
    {
        List<Schrittbearbeitunginfos> Schrittbearbeitunginfos;

        public Schrittbearbeitunginfos currentSchritt { get; private set; }
        public long TimestampNewImageLoadedSeconds { get; private set; }

        public Schritttracker()
        {
            Schrittbearbeitunginfos = generateSchrittbearbeitungsInfos();
            currentSchritt = new Schrittbearbeitunginfos();
            TimestampNewImageLoadedSeconds = 0;
        }

        List<Schrittbearbeitunginfos> generateSchrittbearbeitungsInfos()
        {
            return new List<Schrittbearbeitunginfos>(); // Todo: Import from file
        }

        void setCurrentMitarbeiter(Mitarbeiter mitarbeiter)
        {
            currentSchritt.Mitarbeitername = mitarbeiter.Name;
        }

        void setCurrentAnleitung(Anleitung anleitung)
        {
            currentSchritt.Anleitungsname = anleitung.Name;
        }

        void setCurrentAnleitungsschritt(Anleitungsschritt anleitungsschritt)
        {
            currentSchritt.Anleitungsschrittname = anleitungsschritt.Name;
        }

        void incrementCurrentVersuchszahl()
        {
            currentSchritt.Versuchszahl += 1;
        }

        void setCurrentZeitSekunden(long zeitSekunden)
        {
            currentSchritt.ZeitSekunden = zeitSekunden;
        }

        void submitStep()
        {
            // Log time step spent active
            var nowSeconds = DateTime.Now.Ticks / TimeSpan.TicksPerSecond; // System time in seconds
            var secondsPassedSinceImageWasLoaded = nowSeconds - TimestampNewImageLoadedSeconds;
            setCurrentZeitSekunden(secondsPassedSinceImageWasLoaded);

            if (currentSchritt.isFilledInProperly())
            {
                Schrittbearbeitunginfos.Add(currentSchritt);
                Console.WriteLine("Schritt gespeichert: "+currentSchritt);
                refreshTimestamp();
            }
            else
            {
                throw new Exception("Konnte Schritt nicht in den Schritttracker schreiben: Werte waren nicht komplett und richtig ausgefuellt.");
            }
        }

        void refreshTimestamp()
        {
            TimestampNewImageLoadedSeconds = DateTime.Now.Ticks / TimeSpan.TicksPerSecond; // Logs system time in seconds
        }

        public void setCurrentMitarbeiter(object sender, MitarbeiterArgs e)
        {
            setCurrentMitarbeiter(e.Mitarbeiter);
        }

        public void setCurrentAnleitung(object sender, AnleitungArgs e)
        {
            setCurrentAnleitung(e.Anleitung);
        }
        public void setCurrentAnleitungsschritt(object sender, AnleitungsschrittArgs e)
        {
            setCurrentAnleitungsschritt(e.Anleitungsschritt);
        }

        public void incrementVersuchszahl(object sender, EventArgs e)
        {
            incrementCurrentVersuchszahl();
        }

        public void setZeitSekunden(object sender, ZeitSekundenArgs e)
        {
            setCurrentZeitSekunden(e.ZeitSekunden);
        }

        public void submitStep(object sender, EventArgs e)
        {
            submitStep();
        }


    }
}
