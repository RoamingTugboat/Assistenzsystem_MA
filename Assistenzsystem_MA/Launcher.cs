using System;

namespace Assistenzsystem_MA
{
    class Launcher
    {

        BackendImpl backend;

        public Launcher()
        {
            backend = new BackendImpl();
        }

        public static void Main(string[] args)
        {
            var launcher = new Launcher();
        }
    }
}
