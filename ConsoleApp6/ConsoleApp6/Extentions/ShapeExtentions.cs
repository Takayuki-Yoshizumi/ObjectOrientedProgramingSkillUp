using System.Collections.Generic;
using System.Linq;
using ConsoleApp6.Interface;

namespace ConsoleApp6.Extentions
{
    public static class ShapeExtentions
    {
        public static double CalcShapeAreas(this IEnumerable<IShape> shapes)
        {
            return shapes.Sum(x => x.CalcArea());
        }
    }
}
