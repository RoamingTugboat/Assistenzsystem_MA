using Assistenzsystem_MA.Base.Data;
using System;

namespace Assistenzsystem_MA.Base.Args
{
    class ZeitSekundenArgs : EventArgs
    {
        public long ZeitSekunden { get; private set; }
        public ZeitSekundenArgs(long zeitSekunden)
        {
            ZeitSekunden = zeitSekunden;
        }

    }
}
