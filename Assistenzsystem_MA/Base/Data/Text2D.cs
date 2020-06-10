using System;

namespace Assistenzsystem_MA.Base.Data
{
    [Serializable]
    public class Text2D : Anleitungsmedium2D
    {
        public String Content { get; set; }
        
        public Text2D()
        {

        }

        public Text2D(Point2D position, string content) : base(position)
        {
            Content = content;
        }

        public override string ToString()
        {
            return "\"" + Content + "\" at " + Position;
        }
    }
}
