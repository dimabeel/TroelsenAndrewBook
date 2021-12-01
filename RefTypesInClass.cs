using System;
using System.Collections.Generic;
using System.Text;

namespace Troelsen
{
    class RefTypesInClass
    {
        public static void Test()
        {
            ref var refInArr = ref GetRef(testArr, 2);
            Console.WriteLine(string.Join(',', testArr));
            refInArr = "BeeDooBeeDoo";
            Console.WriteLine(string.Join(',', testArr));
        }

        public static ref string GetRef(string[] arr, int pos) 
        {
            return ref arr[pos];
        }

        static string[] testArr = new string[]
        {
            "one",
            "two",
            "three",
            "four"
        };
    }
}
