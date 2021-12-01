using System;
using System.Collections.Generic;
using System.Text;

namespace Troelsen
{
    public class ParamsInMethod
    {
        public static void Test()
        {
            TestWithParams();
            TestWithParams(0, 1, 2, 3, 4, 5);
            TestWithParams(new int[] { 5, 4, 3, 2, 1, 0 });
        }

        private static void TestWithParams(params int[] nums) 
        {
            foreach(var num in nums)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine(string.Join(',', nums));
            Console.WriteLine(new string('-', 10));
        }
    }
}
