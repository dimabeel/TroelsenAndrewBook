using System;
using System.Collections.Generic;
using System.Text;

namespace Troelsen
{
    class NewSwitchCase
    {
        public static void Test()
        {
            var shapes = new List<Shape>
            {
                new Circle(),
                new Square(2),
                new Triangle(),
                new Square(4),
            };

            foreach (var shape in shapes)
            {
                switch (shape)
                {
                    case Circle c:
                        Console.WriteLine("Circle");
                        break;

                    case Square s when s.Size == 4:
                        Console.WriteLine("Square, 4 size");
                        break;

                    case Square s when s.Size == 2:
                        Console.WriteLine("Square, 2 size");
                        break;

                    case Triangle t:
                        Console.WriteLine("Triangle");
                        break;
                }
            }

            Console.ReadKey();
        }

        public class Shape { }

        public class Circle : Shape { }

        public class Square : Shape
        {
            public Square(int size) : base()
            {
                Size = size;
            }

            public int Size { get; }
        }

        public class Triangle : Shape { }
    }
}
