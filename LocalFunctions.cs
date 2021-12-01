using System;
using System.Collections.Generic;
using System.Text;

namespace Troelsen
{
    public class LocalFunctions
    {
        public static void Test()
        {
            void PrintSomeone()
            {
                Console.WriteLine("Local function called");
            }

            PrintSomeone();
        }
    }
}
