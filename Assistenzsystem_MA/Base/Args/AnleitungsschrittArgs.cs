using Assistenzsystem_MA.Base.Data;
using System;

namespace Assistenzsystem_MA.Base.Args
{
    class AnleitungsschrittArgs : EventArgs
    {
        public Anleitungsschritt Anleitungsschritt { get; private set; }

        public AnleitungsschrittArgs(Anleitungsschritt anleitungsschritt)
        {
            Anleitungsschritt = anleitungsschritt;
        }
    }
}
