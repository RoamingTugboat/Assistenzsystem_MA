using System;

namespace Assistenzsystem_MA 
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
