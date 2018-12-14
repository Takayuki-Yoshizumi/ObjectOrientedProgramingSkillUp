using ConsoleApp6.Interface;

namespace ConsoleApp6.Model
{
    public class Triangle : IShape
    {
        public Triangle(double bottom,double height)
        {
            this.Bottom = bottom;
            this.Height = height;
        }

        public double Bottom { get; }

        public double Height { get; }

        public double CalcArea()
        {
            return this.Bottom * this.Height / 2;
        }
    }
}
