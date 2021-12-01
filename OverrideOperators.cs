using System;
using System.Collections.Generic;
using System.Text;

namespace Troelsen
{
    class OverrideOperators
    {
        public static void Test()
        {
            var p1 = new Point(10, 10);
            var p2 = new Point(20, 20);
            var p3 = new Point(10, 10);
            Console.WriteLine(p1.Equals(p2));
            Console.WriteLine(p1.Equals(p3));
            Console.WriteLine(new string('-', 10));
            p1++;
            Console.WriteLine(p1.ToString());
            Console.WriteLine((p2 + p3).ToString());
            Console.WriteLine((p3 + 3).ToString());
            Console.WriteLine(p1 == p1);
            p1--;
            p1--;
            Console.WriteLine(p1.ToString());
        }

        public class Point
        {
            public static Point operator +(Point p1, Point p2) =>
                new Point(p1.X + p2.X, p1.Y + p2.Y);

            public static Point operator +(int offset, Point p1) =>
                new Point(p1.X + offset, p1.Y + offset);

            public static Point operator +(Point p1, int offset) =>
                new Point(p1.X + offset, p1.Y + offset);

            public static Point operator ++(Point p1) =>
                new Point(p1.X + 1, p1.Y + 1);

            public static Point operator --(Point p1) =>
                new Point(p1.X - 1, p1.Y - 1);

            public override bool Equals(object obj)
            {
                // Can override for == and !=
                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                // Can override for == and !=
                return base.GetHashCode();
            }

            public override string ToString()
            {
                return $"X: {X}, Y: {Y}.";
            }

            public static bool operator ==(Point p1, Point p2) =>
                p1.Equals(p2);

            public static bool operator !=(Point p1, Point p2) =>
                !p1.Equals(p2);

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X { get; set; }

            public int Y { get; set; }
        }
    }
}
