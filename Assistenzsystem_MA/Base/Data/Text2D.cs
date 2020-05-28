namespace Assistenzsystem_MA.Base.Data
{
    using System;
    class Text2D : Anleitungsmedium2D
    {
        public String Content { get; private set; }
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
