using Assistenzsystem_MA.Base.Args;
using Assistenzsystem_MA.Base.Data;
using System;

namespace Assistenzsystem_MA.Base.Components.Kamera
{
    class Bilderkennung
    {
        public EventHandler<EventArgs> OnWrong;
        public EventHandler<EventArgs> OnRight;

        public Bilderkennung()
        {

        }


        //This can be controlled from outside for debugging 
        public void recognizeImageAsRight()
        {
            OnRight?.Invoke(this, new EventArgs());
        }

        //This can be controlled from outside for debugging 
        public void recognizeImageAsWrong()
        {
            OnWrong?.Invoke(this, new EventArgs());
        }
    }
}
