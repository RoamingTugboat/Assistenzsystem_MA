using Assistenzsystem_MA.Base;
using Assistenzsystem_MA.Base.Args;
using Assistenzsystem_MA.Base.Data;
using System;

namespace Assistenzsystem_MA
{
    class Launcher
    {
        static void Main(string[] args)
        {
            new Launcher();
        }

        BackendImpl backend;

        public Launcher()
        {
            backend = new BackendImpl();
            backend.OnAboutToSendNewMedia += clearMedia;
            backend.OnSendingMedium += printMedium;
            Console.WriteLine("Welcome.");
            Console.WriteLine("Available commands: listall, fr, bw, cha <Anleitungsname>, chm <Mitarbeitername>, camr, camw, dd");
            unserInputParseLoop();
        }

        void unserInputParseLoop()
        {
            while (true)
            {
                var line = Console.ReadLine();
                if (line == "listall")
                {
                    backend.listAnleitungen();
                }
                else if (line == "fw")
                {
                    backend.flipForward();
                }
                else if (line == "bw")
                {
                    backend.flipBackward();
                }
                else if (line.StartsWith("cha "))
                {
                    var remainingLine = line.Substring(4);
                    backend.changeAnleitung(remainingLine);
                }
                else if (line.StartsWith("chm "))
                {
                    var remainingLine = line.Substring(4);
                    backend.changeMitarbeiter(remainingLine);
                }
                else if (line == "camr")
                {
                    backend.recognizeImageAsRight();
                }
                else if (line == "camw")
                {
                    backend.recognizeImageAsWrong();
                }
                else if (line == "dd") // For debugging
                {
                    backend.changeMitarbeiter("Jake");
                    backend.changeAnleitung("Kupplung");
                }
                else if (line == "save")
                {
                    backend.saveSchrittdatenbank();
                }
                else if (line == "load")
                {
                    backend.loadSchrittdatenbank();
                }
                else if (line == "print")
                {
                    backend.printSchrittdatenbank();
                }
                else if (line == "exit")
                {
                    backend.saveSchrittdatenbank();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Can't recognize command");
                }
            }
        }

        void clearMedia(object sender, EventArgs e)
        {
            Console.WriteLine(">> CLEARING MEDIA");
        }

        void printMedium(object sender, MediaArgs e)
        {
            var mediaDescription = "";
            if (e.Anleitungsmedium is Text2D)
            {
                mediaDescription += (e.Anleitungsmedium as Text2D);
            }
            Console.WriteLine("Backend sent a " + e.Anleitungsmedium.GetType().Name + " Medium: " + mediaDescription);
        }

    }
}
