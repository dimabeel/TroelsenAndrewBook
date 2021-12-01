using System;
using System.Collections.Generic;
using System.Text;

namespace Troelsen
{
    class ExceptionsTest
    {
        public static void Test()
        {
            try
            {
                Console.WriteLine("Start test run");
                StartTest();
            }
            catch (Exception e) when (e.Message.Contains("Start test except"))
            {
                Console.WriteLine("Called highest catch");
            }
            finally
            {
                Console.WriteLine("Called finally");
            }
        }

        private static void StartTest()
        {
            try
            {
                EndTest();
                Console.WriteLine("End test run");
            }
            catch (Exception e)
            {
                Console.WriteLine(new string('-', 10));
                Console.WriteLine(e.Message);
                throw new Exception("Start test except", e);
            }
        }

        private static void EndTest()
        {
            try
            {
                object s = "str";
                int i = (int)s;
                Console.WriteLine("WOOOO");
            }
            catch (Exception e)
            {
                Console.WriteLine(new string('-', 10));
                Console.WriteLine(e.Message);
                throw new Exception("End test except", e);
            }
        }
    }
}
