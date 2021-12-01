using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TroelsenNetFramework
{
    public class AsyncDelegate
    {
        public delegate int FuncPointer(int x, int y);
        public static void Test()
        {
            AsyncDelegate asyncDelegate = new AsyncDelegate();
            
            FuncPointer sumFunc = asyncDelegate.Sum;
            sumFunc.BeginInvoke(10, 10, 
                asyncDelegate.AsyncCallbackFunction, "It is an anyInfo");

            while(!asyncDelegate.hasCallback)
            {
                Console.WriteLine("Do smth while waiting callback");
                Thread.Sleep(1000);
            }

            Console.ReadKey();
        }

        public int Sum(int x, int y)
        {
            int result = x + y;
            Thread.Sleep(5000);
            Console.WriteLine($"The result is: {result}");
            return result;
        }

        public void AsyncCallbackFunction(IAsyncResult asyncResult)
        {
            Console.WriteLine("The method was successfull (CALLBACK)");
            Console
                .WriteLine($"Any info: {asyncResult.AsyncState}");
            hasCallback = true;
        }

        bool hasCallback = false;
    }
}
