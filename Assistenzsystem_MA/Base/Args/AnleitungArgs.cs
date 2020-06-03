using Assistenzsystem_MA.Base.Data;
using System;

namespace Assistenzsystem_MA.Base.Args
{
    class AnleitungArgs : EventArgs
    {
        public Anleitung Anleitung { get; private set; }
        public AnleitungArgs(Anleitung anleitung)
        {
            Anleitung = anleitung;
        }

    }
}
