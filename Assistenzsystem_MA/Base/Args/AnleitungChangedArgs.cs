using Assistenzsystem_MA.Base.Data;
using System;

namespace Assistenzsystem_MA.Base.Args
{
    class SchrittChangedArgs : EventArgs
    {
        public Anleitungsschritt Anleitungsschritt { get; private set; }

        public SchrittChangedArgs(Anleitungsschritt anleitungsschritt)
        {
            Anleitungsschritt = anleitungsschritt;
        }
    }
}
