using System;
using System.Collections.Generic;
using System.Text;

namespace Troelsen
{
    class ExplicitImplicit
    {
        public static void Test()
        {
            var firstRect = new Rectangle(10, 5);
            var firstSquare = (Square)firstRect;

            var secondSquare = new Square(5);
            Rectangle secondRect = secondSquare;

            Console.WriteLine($"FirstRect. X:{firstRect.X}, Y:{firstRect.Y}.");
            Console.WriteLine($"FirstSquare. Length: {firstSquare.Length}");

            Console.WriteLine($"SecondSquare. Length: {secondSquare.Length}");
            Console.WriteLine($"SecondRect. X:{secondRect.X}, Y:{secondRect.Y}");
        }

        public class Square
        {
            public static explicit operator Square(Rectangle s)
            {
                return new Square(s.X);
            }

            public Square(int length)
            {
                Length = length;
            }

            public int Length { get; set; }
        }

        public class Rectangle
        {
            public static implicit operator Rectangle(Square s)
            {
                return new Rectangle(s.Length, s.Length);
            }

            public Rectangle(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X { get; set; }

            public int Y { get; set; }
        }
    }
}
