using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Threading;
using System.Runtime.Remoting.Contexts;

namespace TroelsenNetFramework
{
    class ThreadsBasic
    {
        static AutoResetEvent autoResetEvent = new AutoResetEvent(false);
        public static void Test()
        {
            string consoleInput = Console.ReadLine();
            var ps = new PrintSomeone();
            switch (consoleInput)
            {
                case "1":
                    ps.Print();
                    break;

                case "2":
                    var thread = new Thread(ps.Print);
                    thread.Name = "Secondary";
                    thread.Start();
                    break;

                case "3":
                    for(int i = 0; i < 10; i++)
                    {
                        var parallelizmTest = new Thread(ps.Print);
                        parallelizmTest.Name = i.ToString();
                        parallelizmTest.Start();
                    }
                    break;

                default:
                    Console.WriteLine("Nice dick, bro. Try again (1 or 2)");
                    break;
            }

            autoResetEvent.WaitOne();
            var currThread = Thread.CurrentThread;
            currThread.Name = "Primary";
            Console.WriteLine($"Main thread is working: {currThread.Name}");
            Console.ReadKey();
        }

        [Synchronization]
        public class PrintSomeone : ContextBoundObject
        {
            public void Print()
            {
                var currThread = Thread.CurrentThread;
                Console.WriteLine($"Working thread is: {currThread.Name}." +
                    $"Id: {currThread.ManagedThreadId}");
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(1); // For parallelizm set to 1 (case 3)
                    Console.Write($"{i}, ");
                }
                Console.WriteLine();
                autoResetEvent.Set();
            }
        }
    }
}
