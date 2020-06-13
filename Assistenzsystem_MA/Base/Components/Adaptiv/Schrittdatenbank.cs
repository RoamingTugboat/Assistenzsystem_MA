using System;
using Assistenzsystem_MA.Base.Data;
using System.Collections.Generic;
using Assistenzsystem_MA.Base.Args;
using System.Xml.Serialization;
using System.IO;

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

        public void submitStep(bool stepWasExecutedCorrectly)
        {
            currentSchritt.Timestamp = DateTime.Now;

            // Log time step spent active:
            var nowSeconds = DateTime.Now.Ticks / TimeSpan.TicksPerSecond; // System time in seconds
            var secondsPassedSinceImageWasLoaded = nowSeconds - TimestampNewImageLoadedSeconds;
            currentSchritt.ZeitSekunden = secondsPassedSinceImageWasLoaded;

            if (currentSchritt.isFilledInProperly())
            {
                currentSchritt.VersuchErfolgreich = stepWasExecutedCorrectly;
                Schrittbearbeitunginfos.Add(currentSchritt.Copy());
                Console.WriteLine("Saved: "+currentSchritt);
            }
            else
            {
                Console.WriteLine("Konnte Schritt nicht in den Schritttracker schreiben: Werte waren nicht komplett und richtig ausgefuellt");
            }
        }


        public void setCurrentMitarbeiter(object sender, MitarbeiterArgs e)
        {
            currentSchritt.Mitarbeiter = e.Mitarbeiter;
        }

        public void setCurrentAnleitung(object sender, AnleitungArgs e)
        {
            currentSchritt.Anleitung = e.Anleitung;
        }

        public void setCurrentAnleitungsschritt(object sender, AnleitungsschrittArgs e)
        {
            currentSchritt.Anleitungsschritt = e.Anleitungsschritt;
            refreshSchrittLoadTimestamp();
        }

        void refreshSchrittLoadTimestamp()
        {
            TimestampNewImageLoadedSeconds = DateTime.Now.Ticks / TimeSpan.TicksPerSecond; // Logs system time in seconds
        }

        public void resetCurrentStep(object sender, EventArgs e)
        {
            currentSchritt = new Schrittbearbeitunginfos();
            refreshSchrittLoadTimestamp();
        }

        public void trySubmitCurrentStepRight(object sender, EventArgs e)
        {
            submitStep(true);
        }

        public void trySubmitCurrentStepWrong(object sender, EventArgs e)
        {
            submitStep(false);
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
                // If XML file exists but is empty, load empty DB to prevent XML parsing exception:
                if(new FileInfo(filename).Length == 0)
                {
                    Schrittbearbeitunginfos = new List<Schrittbearbeitunginfos>();
                }
                // If XML file exists and contains data, load DB from it:
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
