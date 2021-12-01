using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Troelsen
{
    class ThreadAsyncAwait
    {
        public void Test()
        {
            while(true)
            {
                string result = Console.ReadLine();
                switch(result)
                {
                    case "Q":
                        Environment.Exit(0);
                        break;

                    case "Test":
                        Operation();
                        break;

                    case "AsyncVoid":
                        OperationAsync();
                        break;

                    case "AsyncFunc":
                        var task = DoSmthAsync();
                        task.ContinueWith((t) =>
                        {
                            Console.WriteLine($"AsyncFunc ended. Result: {t.Result}.");
                        });
                        break;
                }
            }
        }

        public async void OperationAsync()
        {
            await Task.Run(() => Operation());
        }

        private void Operation()
        {
            Console.WriteLine($"Operation started ThId {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(10000);
            Console.WriteLine("Operation ended");
        }

        public async Task<string> DoSmthAsync()
        {
            return await Task.Factory.StartNew(DoSmth);
        }

        private string DoSmth()
        {
            Thread.Sleep(2000);
            return "Bla bla bla bla";
        }

        //1. Main method which will be process ASYNC result
        //2. async method which return await result (Task, Task<T>)
        //3. usuall method which return result. 
        //Note: Main CALL async CALL usual, then
        //      usual RETURN value to async
        //      async RETURN task to main
        //      main has TASK and can manipulate with it.

        //If we would like run just any thread without getting result
        //we can use Task.Run(), i mean this will be enough.
    }
}
