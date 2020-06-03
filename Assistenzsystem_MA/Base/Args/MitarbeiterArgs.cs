using Assistenzsystem_MA.Base.Data;
using System;

namespace Assistenzsystem_MA.Base.Args
{
    class MitarbeiterArgs : EventArgs
    {
        public Mitarbeiter Mitarbeiter { get; private set; }
        public MitarbeiterArgs(Mitarbeiter mitarbeiter)
        {
            Mitarbeiter = mitarbeiter;
        }

    }
}
