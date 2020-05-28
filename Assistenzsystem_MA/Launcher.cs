using System;

namespace Assistenzsystem_MA
{
    class Launcher
    {

        BackendImpl backend;

        public Launcher()
        {
            backend = new BackendImpl();
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
                else if (line == "forward")
                {
                    backend.flipForward();
                }
                else if (line == "backward")
                {
                    backend.flipBackward();
                }
            }
        }


        public static void Main(string[] args)
        {
            new Launcher();
        }

    }
}
