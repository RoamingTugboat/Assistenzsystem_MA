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
            if(Content.Length < 30)
            {
                return "\"" + Content + "\" " + Position;
            }
            else
            {
                return "\"" + Content.Substring(0,27) + "...\" " + Position;
            }
        }
    }
}
