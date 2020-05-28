using Assistenzsystem_MA.Base.Data;
using System;

namespace Assistenzsystem_MA.Base.Args
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
