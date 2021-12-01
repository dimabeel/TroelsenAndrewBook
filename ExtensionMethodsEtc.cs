using System;
using System.Collections.Generic;
using System.Text;

namespace Troelsen
{
    class ExtensionMethodsEtc
    {
        public static void Test()
        {
            int i = 12345;
            Console.WriteLine(i.ToString());
            i = i.ReverseOrder();
            Console.WriteLine(i.ToString());
        }
    }

    static class Extensions
    {
        public static int ReverseOrder(this int i)
        {
            var intToStr = i.ToString().ToCharArray();
            Array.Reverse(intToStr);
            var newStr = new string(intToStr);
            return int.Parse(newStr);
        }
    }
}
