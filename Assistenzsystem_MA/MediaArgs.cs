using System;

namespace Assistenzsystem_MA 
{
    class MediaArgs : EventArgs
    {
        public Anleitungsmedium Anleitungsmedium { get; private set; }

        public MediaArgs(Anleitungsmedium anleitungsmedium)
        {
            Anleitungsmedium = anleitungsmedium;
        }
    }
}
