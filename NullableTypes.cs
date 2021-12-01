using System;
using System.Collections.Generic;
using System.Text;

namespace Troelsen
{
    public class NullableTypes
    {
        public static void Test()
        {
            int? nullableInt = null;
            PrintValue(nullableInt);
            nullableInt = 1;
            PrintValue(nullableInt);
        }

        private static void PrintValue(int? value)
        {
            if(value.HasValue)
            {
                Console.WriteLine($"Value is: {value}");
            }
            else
            {
                Console.WriteLine($"Value is undefined, {value ?? 0}");
            }
        }
    }
}
