using ConsoleApp6.Interface;

namespace ConsoleApp6.Model
{
    public class Square : IShape
    {
        public Square(double bottom, double height)
        {
            this.Bottom = bottom;
            this.Height = height;
        }

        public double Bottom { get; }

        public double Height { get; }

        public double CalcArea()
        {
            return this.Bottom * this.Height;
        }
    }
}
