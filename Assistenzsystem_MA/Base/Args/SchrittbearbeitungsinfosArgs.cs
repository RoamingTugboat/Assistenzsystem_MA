using Assistenzsystem_MA.Base.Data;
using System;
using System.Collections.Generic;

namespace Assistenzsystem_MA.Base.Args
{
    class SchrittbearbeitungsinfosArgs : EventArgs
    {
        public List<Schrittbearbeitunginfos> Schrittbearbeitunginfos { get; private set; }
        public SchrittbearbeitungsinfosArgs(List<Schrittbearbeitunginfos> schrittbearbeitunginfos)
        {
            Schrittbearbeitunginfos = schrittbearbeitunginfos;
        }

    }
}
