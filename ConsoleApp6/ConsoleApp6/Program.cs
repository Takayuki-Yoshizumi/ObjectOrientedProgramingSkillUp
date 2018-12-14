using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ConsoleApp6.Extentions;
using ConsoleApp6.Interface;
using ConsoleApp6.Model;

namespace ConsoleApp6
{
    public class Program
    {
        private static string StartStr(string title)
        {
            return $"========================{title}Start========================\n";
        }

        private static string EndStr(string title)
        {
            return $"\n========================={title}End=========================\n";
        }

        static void Main(string[] args)
        {
            var title = "処理";
            StartStr(title);
            var fileName = args[0];
            var lines = new List<string>();

            using (var sr = new StreamReader(fileName, Encoding.UTF8, false))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            var parsedArgs = new List<ParsedArgs>();
            foreach (var arg in lines.Skip(1))
            {
                parsedArgs.Add(new ParsedArgs(arg));
            }

            var triList = new List<Triangle>();
            var squList = new List<Square>();
            var cirList = new List<Circle>();

            // TriangleのList,SquareのList,CircleのListの作成
            foreach (var arg in parsedArgs)
            {
                if (double.TryParse(arg.TriangleBottom, out var bottom) && double.TryParse(arg.TriangleHeight, out var height))
                {
                    triList.Add(new Triangle(bottom, height));
                }

                if (double.TryParse(arg.SquareBottom, out var squBottom) && double.TryParse(arg.SquareHeight, out var squHeight))
                {
                    squList.Add(new Square(squBottom, squHeight));
                }

                if (double.TryParse(arg.CircleRadius, out var radius))
                {
                    cirList.Add(new Circle(radius));
                }
            }

            Task2nd(triList);

            Task3rd(triList);

            Task4th(triList);

            Task5th(triList);

            Task6th(triList);

            Task7th(triList);

            Task8th(triList);

            Task9th(triList);

            Task11th(squList);

            Task12th(squList);

            Task14th(cirList);

            Task15th(cirList);

            Task17th(cirList);

            EndStr(title);
        }

        private static void Task2nd(IEnumerable<Triangle> triangles)
        {
            var title = "No2";
            Console.WriteLine(StartStr(title));

            int count = 1;

            foreach (var triangle in triangles)
            {
                Console.WriteLine($"{count}. {triangle.CalcArea()}");
                count++;
            }

            Console.WriteLine(EndStr(title));
        }

        private static void Task3rd(IEnumerable<Triangle> triangles)
        {
            var title = "No3";
            Console.WriteLine(StartStr(title));

            foreach (var triangle in triangles)
            {
                if (triangle.CalcArea() >= 1000)
                {
                    Console.WriteLine("面積が1000以上の三角形は存在する");
                    break;
                }
            }

            Console.WriteLine(EndStr(title));
        }

        private static void Task4th(IEnumerable<Triangle> triangles)
        {
            var title = "No4";
            Console.WriteLine(StartStr(title));

            if (triangles.Any(x => x.CalcArea() >= 1000))
            {
                Console.WriteLine("面積が1000以上の三角形は存在する");
            }

            Console.WriteLine(EndStr(title));
        }

        private static void Task5th(IEnumerable<Triangle> triangles)
        {
            var title = "No5";
            Console.WriteLine(StartStr(title));

            Console.WriteLine($"初めて面積が1000を超えたときの値：{triangles.FirstOrDefault(x => x.CalcArea() >= 1000).CalcArea()}");

            Console.WriteLine(EndStr(title));
        }

        private static void Task6th(IEnumerable<Triangle> triangles)
        {
            var title = "No6";
            Console.WriteLine(StartStr(title));

            Console.WriteLine($"初めて面積が1000を超えたときの列番号：{triangles.Select((x, index) => new { triangle = x,index}).FirstOrDefault(x => x.triangle.CalcArea() >= 1000).index + 1}");

            Console.WriteLine(EndStr(title));
        }

        private static void Task7th(IEnumerable<Triangle> triangles)
        {
            var title = "No7";
            Console.WriteLine(StartStr(title));

            Console.WriteLine($"面積が1000を超えている三角形の数：{triangles.Count(x => x.CalcArea() >= 1000)}");

            Console.WriteLine(EndStr(title));
        }

        private static void Task8th(IEnumerable<Triangle> triangles)
        {
            var title = "No8";
            Console.WriteLine(StartStr(title));

            Console.WriteLine($"三角形の面積の平均値：{triangles.Average(x => x.CalcArea())}");

            Console.WriteLine(EndStr(title));
        }

        private static void Task9th(IEnumerable<Triangle> triangles)
        {
            var title = "No9";
            Console.WriteLine(StartStr(title));

            int count = 1;

            foreach (var triangle in triangles.OrderByDescending(x => x.CalcArea()))
            {
                Console.WriteLine($"{count}. {triangle.CalcArea()}");
                count++;
            }

            Console.WriteLine(EndStr(title));
        }

        private static void Task11th(IEnumerable<Square> squares)
        {
            var title = "No11";
            Console.WriteLine(StartStr(title));

            int count = 1;

            foreach (var square in squares)
            {
                Console.WriteLine($"{count}. {square.CalcArea()}");
                count++;
            }

            Console.WriteLine(EndStr(title));
        }

        private static void Task12th(IEnumerable<Square> squares)
        {
            var title = "No12";
            Console.WriteLine(StartStr(title));

            if (squares.Any(x => x.CalcArea() >= 1000))
            {
                Console.WriteLine("面積が1000以上の四角形は存在する");
            }

            Console.WriteLine(EndStr(title));
        }

        private static void Task14th(IEnumerable<Circle> circles)
        {
            var title = "No14";
            Console.WriteLine(StartStr(title));

            int count = 1;

            foreach (var circle in circles)
            {
                Console.WriteLine($"{count}. {circle.CalcArea()}");
                count++;
            }

            Console.WriteLine(EndStr(title));
        }

        private static void Task15th(IEnumerable<Circle> circles)
        {
            var title = "No15";
            Console.WriteLine(StartStr(title));

            if (circles.Any(x => x.CalcArea() >= 1000))
            {
                Console.WriteLine("面積が1000以上の円は存在する");
            }

            Console.WriteLine(EndStr(title));
        }
        private static void Task17th(IEnumerable<IShape> shapes)
        {
            var title = "No17";
            Console.WriteLine(StartStr(title));

            Console.WriteLine($"すべての図形の面積の合計は：{shapes.CalcShapeAreas()}");

            Console.WriteLine(EndStr(title));
        }
    }

    public class ParsedArgs
    {
        public ParsedArgs(string args)
        {
            var fragment = args.Split(',');
            this.TriangleBottom = fragment[0];
            this.TriangleHeight = fragment[1];
            this.SquareBottom = fragment[2];
            this.SquareHeight = fragment[3];
            this.CircleRadius = fragment[4];
        }

        /// <summary>
        /// 三角形の底辺
        /// </summary>
        public string TriangleBottom { get; set; }

        /// <summary>
        /// 三角形の高さ
        /// </summary>
        public string TriangleHeight { get; set; }

        /// <summary>
        /// 正方形の底辺
        /// </summary>
        public string SquareBottom { get; set; }

        /// <summary>
        /// 正方形の高さ
        /// </summary>
        public string SquareHeight { get; set; }

        /// <summary>
        /// 円の半径
        /// </summary>
        public string CircleRadius { get; set; }
    }
}
