using Assistenzsystem_MA.Base.Args;
using Assistenzsystem_MA.Base.Data;
using System;
using System.Collections.Generic;

namespace Assistenzsystem_MA.Base.Components.Anleitungen
{
    class Anleitungszustand
    {
        public EventHandler<AnleitungArgs> OnAnleitungSet;
        public EventHandler<AnleitungsschrittArgs> OnAnleitungsschrittChanged;
        public EventHandler<AnleitungArgs> OnAnleitungUnloaded;

        public List<Anleitung> Anleitungsdatenbank { get; private set; }
        public Anleitung Anleitung { get; private set; }
        int currentStep;
        public int CurrentStep
        {
            get
            {
                return currentStep;
            }
            private set
            {
                if (Anleitung == null)
                {
                    //Console.WriteLine("Anleitung ist auf null, kann deshalb schritt nicht aendern");
                    return;
                }
                if (value == currentStep)
                {
                    //Console.WriteLine("Anleitungsschritt wurde wiederholt auf den selben Wert gesetzt.");
                }
                if (0 <= value && value < Anleitung.Schrittzahl)
                {
                    //Console.WriteLine(Anleitung.Name + " war auf Schritt " + currentStep + ", wechselt auf " + value);
                    currentStep = value;
                    OnAnleitungsschrittChanged?.Invoke(this, new AnleitungsschrittArgs(Anleitung.Anleitungsschritts[currentStep]));
                }
                else if (Anleitung.Schrittzahl <= value)
                {
                    //Console.WriteLine("Neuer Schritt soll #" + value + " sein, aber die Anleitung hat nur " + Anleitung.Schrittzahl + " Schritte. Anleitung ist fertig und wird entfernt.");
                    var unloadedAnleitung = unloadAnleitung();
                    OnAnleitungUnloaded?.Invoke(this, new AnleitungArgs(unloadedAnleitung));
                }
            }
        }

        public Anleitungszustand()
        {
            Anleitungsdatenbank = new List<Anleitung>() { generateTestAnleitung() };
        }

        Anleitung generateTestAnleitung()
        {
            var Schritt1 = new Anleitungsschritt(
                "Schritt1",
                new List<MediumWithInfos>
                {
                    new MediumWithInfos(
                        new Text2D(new Point2D(0.5f,0.9f), "Legen Sie einen Kupplungskorb auf den Tisch."),
                        new Assistenzinformationen(0)
                    ),
                    new MediumWithInfos(
                        new Bild2D(new Point2D(0.5f,0.5f), "imagename.jpg"),
                        new Assistenzinformationen(1)
                    )
                }
            );
            var Schritt2 = new Anleitungsschritt(
                "Schritt2",
                new List<MediumWithInfos>
                {
                    new MediumWithInfos(
                        new Text2D(new Point2D(0.5f,0.5f), "Nehmen Sie ein Kupplungsrad aus dem Schrank und fuegen sie das Kupplungsrad in den Kupplungskorb ein. Die Korkseite des Rades soll nach oben zeigen."),
                        new Assistenzinformationen(0)
                    ),
                    new MediumWithInfos(
                        new Bild2D(new Point2D(0.5f,0.5f), "imagename.jpg"),
                        new Assistenzinformationen(1)
                    )
                }
            );
            var Schritt3 = new Anleitungsschritt(
                "Schritt3",
                new List<MediumWithInfos>
                {
                    new MediumWithInfos(
                        new Text2D(new Point2D(0.5f,0.5f), "Ende der Anleitung."),
                        new Assistenzinformationen(0)
                    )
                }
            );
            return new Anleitung("Kupplung", new List<Anleitungsschritt> { Schritt1, Schritt2, Schritt3 });
        }

        public void changeAnleitung(string newAnleitungName)
        {
            foreach (var anleitung in this.Anleitungsdatenbank)
            {
                if (anleitung.Name.Equals(newAnleitungName))
                {
                    Anleitung = anleitung;
                    Console.WriteLine("Changed Anleitung to \""+anleitung.Name+"\".");
                    CurrentStep = 0;
                    OnAnleitungSet?.Invoke(this, new AnleitungArgs(Anleitung));
                    return;
                }
            }
            throw new Exception("Anleitung mit diesem Namen existiert nicht: " + newAnleitungName);
        }

        public Anleitung unloadAnleitung()
        {
            var unloadedAnleitung = Anleitung;
            Anleitung = null;
            return unloadedAnleitung;
        }

        public void flipForward(object sender, EventArgs e)
        {
            flipForward();
        }

        public void flipForward()
        {
            CurrentStep += 1;
        }

        public void flipBackward()
        {
            CurrentStep -= 1;
        }

        public void reloadStep(object sender, EventArgs e)
        {
            OnAnleitungsschrittChanged?.Invoke(this, new AnleitungsschrittArgs(Anleitung.Anleitungsschritts[currentStep]));
        }

    }
}
