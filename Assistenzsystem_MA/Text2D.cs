using System;

namespace Assistenzsystem_MA
{
    class Text2D : Anleitungsmedium2D
    {
        public String Content { get; private set; }
        public Text2D(Point2D position, string content) : base(position)
        {
            Content = content;
        }

    }
}
