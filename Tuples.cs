using System;
using System.Collections.Generic;
using System.Text;

namespace Troelsen
{
    class Tuples
    {
        static Tuples()
        {
            integerA = 0;
            stringB = string.Empty;
        }
        public static void Test()
        {
            var testData = GetTestData();
            Console.WriteLine($"{testData.a}, {testData.b}");

            SetTestData((1, "ChangedTuple"));
            var newTestData = GetTestData();
            Console.WriteLine($"{newTestData.a}, {newTestData.b}");

            var newTuple = (a: 1, b: "SecondTest");
            SetTestData(newTuple);
            var newTupleAfterChange = Dec();
            Console.WriteLine($"{newTupleAfterChange.c}, {newTupleAfterChange.d}");
        }

        private static (int a, string b) GetTestData()
        {
            return (integerA, stringB);
        }
        // GetTestData == Dec
        public static (int c, string d) Dec() => (integerA, stringB);

        private static void SetTestData((int a, string b) tuple)
        {
            integerA = tuple.a;
            stringB = tuple.b;
        }

        static int integerA;
        static string stringB;
    }
}
