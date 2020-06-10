using System;
using Assistenzsystem_MA.Base.Data;
using System.Collections.Generic;
using Assistenzsystem_MA.Base.Args;
using System.Xml.Serialization;
using System.IO;
using System.Globalization;

namespace Assistenzsystem_MA.Base.Components.Adaptiv
{
    class Schrittdatenbank
    {
        List<Schrittbearbeitunginfos> Schrittbearbeitunginfos { get; set; }
        public Schrittbearbeitunginfos currentSchritt { get; private set; }
        public long TimestampNewImageLoadedSeconds { get; private set; }

        public Schrittdatenbank()
        {
            loadFromFile("schrittdaten.xml");
            currentSchritt = new Schrittbearbeitunginfos();
            TimestampNewImageLoadedSeconds = 0;
        }


        void setCurrentMitarbeiter(Mitarbeiter mitarbeiter)
        {
            currentSchritt.Mitarbeiter = mitarbeiter;
        }

        void setCurrentAnleitung(Anleitung anleitung)
        {
            currentSchritt.Anleitung = anleitung;
        }

        void setCurrentAnleitungsschritt(Anleitungsschritt anleitungsschritt)
        {
            currentSchritt.Anleitungsschritt = anleitungsschritt;
            refreshLoadtimeTimestamp();
        }

        void incrementCurrentVersuchszahl()
        {
            currentSchritt.Versuchszahl += 1;
        }

        void setCurrentZeitSekunden(long zeitSekunden)
        {
            currentSchritt.ZeitSekunden = zeitSekunden;
        }

        public void submitStep()
        {
            currentSchritt.Timestamp = DateTime.Now;

            // Log time step spent active
            var nowSeconds = DateTime.Now.Ticks / TimeSpan.TicksPerSecond; // System time in seconds
            var secondsPassedSinceImageWasLoaded = nowSeconds - TimestampNewImageLoadedSeconds;
            setCurrentZeitSekunden(secondsPassedSinceImageWasLoaded);

            if (currentSchritt.isFilledInProperly())
            {
                Schrittbearbeitunginfos.Add(currentSchritt.Copy());
                Console.WriteLine("Schritt gespeichert: "+currentSchritt);
            }
            else
            {
                Console.WriteLine("Konnte Schritt nicht in den Schritttracker schreiben: Werte waren nicht komplett und richtig ausgefuellt");
            }
        }

        void refreshLoadtimeTimestamp()
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

        public void saveToFile(string filename)
        {
            var serializer = new XmlSerializer(typeof(List<Schrittbearbeitunginfos>));
            using (var writer = new StreamWriter(filename))
            {
                serializer.Serialize(writer, Schrittbearbeitunginfos);
            }
        }

        public void loadFromFile(string filename)
        {
            var serializer = new XmlSerializer(typeof(List<Schrittbearbeitunginfos>));
            using (var reader = new FileStream(filename, FileMode.OpenOrCreate))
            {
                if(new FileInfo(filename).Length == 0)
                {
                    Schrittbearbeitunginfos = new List<Schrittbearbeitunginfos>();
                }
                else
                {
                    Schrittbearbeitunginfos = (List<Schrittbearbeitunginfos>)serializer.Deserialize(reader);
                }
            }
        }

        public void print()
        {
            foreach(var schrittinfos in Schrittbearbeitunginfos)
            {
                Console.WriteLine(schrittinfos);
            }
        }

    }
}
