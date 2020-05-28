namespace Assistenzsystem_MA
{
    class Point2D
    {

        public float X { get; private set; }
        public float Y { get; private set; }

        public Point2D(float x, float y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            return obj is Point2D d &&
                   X == d.X &&
                   Y == d.Y;
        }

        public override int GetHashCode()
        {
            int hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "(" + X + "|" + Y + ")";
        }

    }
}
