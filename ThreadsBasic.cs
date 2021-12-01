using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Threading;

namespace Troelsen
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

                case "4":
                    var workItem = new WaitCallback(ps.Print);
                    for(int i = 0; i < 10; i++)
                    {
                        ThreadPool.QueueUserWorkItem(workItem);
                        // 10 times in queue
                    }

                    Console.WriteLine("All task queued");
                    break;

                default:
                    Console.WriteLine("Nice dick, bro. Try again (1 or 2, 3, 4)");
                    break;
            }

            autoResetEvent.WaitOne();
            var currThread = Thread.CurrentThread;
            currThread.Name = "Primary";
            Console.WriteLine($"Main thread is working: {currThread.Name}");
            Console.ReadKey();
        }

        public class PrintSomeone
        {
            public void Print(object args = null)
            {
                //Monitor.Enter(this);
                lock (this)
                //try
                {
                    var currThread = Thread.CurrentThread;
                    Console.WriteLine($"Working thread is: {currThread.Name}." +
                        $"Id: {currThread.ManagedThreadId}");
                    for (int i = 0; i < 10; i++)
                    {
                        Thread.Sleep(5); // For parallelizm set to 5 (case 3)
                        Console.Write($"{i}, ");
                    }
                    Console.WriteLine();
                    autoResetEvent.Set();
                }
                //finally
                //{
                //    Monitor.Exit(this);
                //}
            }
        }
    }
}
