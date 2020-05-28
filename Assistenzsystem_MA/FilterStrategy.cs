using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistenzsystem_MA
{
    abstract class FilterStrategy
    {
        public FilterStrategy()
        {
            
        }

        public abstract Anleitungsschritt filter(Anleitungsschritt anleitungsschritt);
    }
}
