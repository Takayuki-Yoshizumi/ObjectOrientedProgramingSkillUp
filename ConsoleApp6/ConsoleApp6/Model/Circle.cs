using System;
using ConsoleApp6.Interface;

namespace ConsoleApp6.Model
{
    public class Circle : IShape
    {
        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius { get; }

        public double CalcArea()
        {
            return Math.Pow(this.Radius, 2) * Math.PI;
        }
    }
}
