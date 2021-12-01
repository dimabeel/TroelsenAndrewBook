using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace Troelsen
{
    public static class BigIntegerTest
    {
        public static void Test()
        {
            BigInteger integer =
                new BigInteger(new byte[] 
                { 1, 2, 3, 4, 5, 6, 7, 1, 2, 3, 4, 5, 6, 7, 
                    2, 3, 4, 5, 6, 7, 1, 2, 3, 4, 5, 6, 7 });

            Console.WriteLine($"BigInteger: {integer}");
            Console.WriteLine($"Type: {integer.GetType().Name}");
            BigInteger powInteger = BigInteger.Pow(integer, 2);
            Console.WriteLine($"Pow integer: {powInteger}");
            Console.WriteLine($"One: {BigInteger.One}");
            Console.WriteLine($"MinusOne: {BigInteger.MinusOne}");
            Console.ReadKey();
        }
    }
}
