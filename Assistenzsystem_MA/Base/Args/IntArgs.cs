using System;

namespace Assistenzsystem_MA.Base.Args
{
    class IntArgs : EventArgs
    {
        public int I { get; private set; }
        public IntArgs(int i)
        {
            I = i;
        }

    }
}
