using System;
using System.Collections.Generic;

namespace Assistenzsystem_MA
{
    class Anleitungszustand
    {
        public EventHandler<SchrittChangedArgs> OnSchrittChanged;

        public List<Anleitung> Anleitungsdatenbank { get; private set; }
        public Anleitung Anleitung { get; private set; }
        int currentStep;
        public int CurrentStep
        {
            get{
                return currentStep;
            }
            set
            {
                if (Anleitung == null)
                {
                    throw new Exception("Anleitung ist auf null, kann deshalb schritt nicht aendern");
                }
                if (0 <= value && value < Anleitung.Schrittzahl)
                {
                    Console.WriteLine("Schritt was " + currentStep + ", changing to " +value);
                    currentStep = value;
                    OnSchrittChanged?.Invoke(this, new SchrittChangedArgs(Anleitung.Anleitungsschritts[currentStep]));
                }
                else
                {
                    Console.WriteLine("Neuer schritt soll #" + value + " sein aber die Anleitung hat nur " + Anleitung.Schrittzahl + " Schritte");
                }
            }
        }

        public Anleitungszustand()
        {
            Anleitungsdatenbank = new List<Anleitung>();
            Anleitungsdatenbank.Add(generateTestAnleitung());
        }

        Anleitung generateTestAnleitung()
        {
            var Schritt1 = new Anleitungsschritt("Schritt1", new List<Anleitungsmedium>{
                new Text2D(new Point2D(0.5f,0.5f),"Schmeiss den Kupplungskorb auf den Tisch")
            });

            var Schritt2 = new Anleitungsschritt("Schritt2", new List<Anleitungsmedium>{
                new Text2D(new Point2D(0.5f, 0.5f), "Reiss dir ein Kupplungsrad aus dem Schrank"),
            });

            var Schritt3 = new Anleitungsschritt("Schritt3", new List<Anleitungsmedium>{
                new Text2D(new Point2D(0.5f, 0.5f), "Und schmeiss das in den Korb volle Kanne rein damit das haelt"),
            });

            var Schritt4 = new Anleitungsschritt("Schritt3", new List<Anleitungsmedium>{
                new Text2D(new Point2D(0.5f, 0.5f), "Voll gut")
            });

            var lamellenkupplungsanleitung = new Anleitung("Lamellenkupplung", new List<Anleitungsschritt> { Schritt1, Schritt2, Schritt3, Schritt4 });

            return lamellenkupplungsanleitung;
        }

        public void changeAnleitung(string newAnleitungName)
        {
            foreach (var anleitung in this.Anleitungsdatenbank)
            {
                if(anleitung.Name.Equals(newAnleitungName))
                {
                    Anleitung = anleitung;
                    CurrentStep = 0;
                    return;
                }
            }
            throw new Exception("Anleitung mit diesem Namen existiert nicht: "+newAnleitungName);
        }

        public void flipForward()
        {
            CurrentStep += 1;
        }

        public void flipBackward()
        {
            CurrentStep -= 1;
        }

    }
}
