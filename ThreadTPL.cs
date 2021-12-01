using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Troelsen
{
    class ThreadTPL
    {
        private static CancellationTokenSource cancelParallelFor;
        private static CancellationTokenSource cancelParallelForeach;
        private static CancellationTokenSource plinqCancellationSource;

        static ThreadTPL()
        {
            cancelParallelFor = new CancellationTokenSource();
            cancelParallelForeach = new CancellationTokenSource();
            plinqCancellationSource = new CancellationTokenSource();
        }

        public static void Test()
        {
            while(true)
            {
                Console.WriteLine($"Main thread id: {Thread.CurrentThread.ManagedThreadId}");
                var result = Console.ReadLine();
                switch(result)
                {
                    case "runTest":
                        cancelParallelFor = new CancellationTokenSource();
                        cancelParallelForeach = new CancellationTokenSource();
                        Task.Factory.StartNew(() => TestParallelForAndForeach());
                        break;
                    case "b1":
                        cancelParallelFor.Cancel();
                        break;
                    case "b2":
                        cancelParallelForeach.Cancel();
                        break;

                    case "PLINQ":
                        plinqCancellationSource = new CancellationTokenSource();
                        Task.Factory.StartNew(() => TestPLINQ());
                        break;

                    case "LINQ":
                        Task.Factory.StartNew(() => TestLINQ());
                        break;

                    case "b3":
                        plinqCancellationSource.Cancel();
                        break;
                }
            }
        }

        public static void TestParallelForAndForeach()
        {
            Console.WriteLine("TestParallelForAndForeach run");
            Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId}");

            var forOptions = new ParallelOptions();
            forOptions.CancellationToken = cancelParallelFor.Token;
            forOptions.MaxDegreeOfParallelism = Environment.ProcessorCount;

            var foreachOptions = new ParallelOptions();
            foreachOptions.CancellationToken = cancelParallelForeach.Token;
            forOptions.MaxDegreeOfParallelism = Environment.ProcessorCount;

            try
            {
                Console.WriteLine("Run parallel for");
                Parallel.For(0, 10, forOptions, i =>
                {
                    Console.WriteLine($"Thread id: {Thread.CurrentThread.ManagedThreadId}");
                    Thread.Sleep(5000);
                    forOptions.CancellationToken.ThrowIfCancellationRequested();
                    Console.WriteLine($"Work num: {i}");
                });
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}" +
                    $" was interrupted in func RunparallelFor");
            }

            try
            {
                Console.WriteLine("Run parallel foreach");
                int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                Parallel.ForEach(nums, foreachOptions, num =>
                {
                    Console.WriteLine($"Thread id: {Thread.CurrentThread.ManagedThreadId}");
                    Thread.Sleep(5000);
                    foreachOptions.CancellationToken.ThrowIfCancellationRequested();
                    Console.WriteLine($"Work num: {num}");
                });
            }
            catch (OperationCanceledException e) 
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}" +
                    $" was interrupted in func RunparallelForeach");
            }

            //https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/how-to-write-a-simple-parallel-foreach-loop
            // Interesting expample from Microsoft. Andrew Troelsen offered to make WPF and use Dispatcher to
            // multi-thread access in Form. The result will be the same but we will have another outpur interface, no more.
        }

        public static void TestPLINQ()
        {
            int[] arr = Enumerable.Range(1, 100_000_000).ToArray();
            int[] findedNums;
            try
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                findedNums = arr.AsParallel().WithCancellation(plinqCancellationSource.Token)
                    .Where(x => x % 3 == 0)
                    .OrderBy(x => x)
                    .Select(x => x).
                    ToArray();
                Console.WriteLine($"Count PLINQ % 3: {findedNums.Length}.");
                stopWatch.Stop();
                Console.WriteLine($"PLINQ time: {stopWatch.ElapsedMilliseconds}");
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine("TestPLINQ was broken");
            }
        }

        public static void TestLINQ()
        {
            int[] arr = Enumerable.Range(1, 100_000_000).ToArray();
            int[] findedNums;

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            findedNums = arr.Where(x => x % 3 == 0)
                    .OrderBy(x => x)
                    .Select(x => x).
                    ToArray();
            Console.WriteLine($"Count PLINQ % 3: {findedNums.Length}.");
            stopWatch.Stop();
            Console.WriteLine($"LINQ time: {stopWatch.ElapsedMilliseconds}");
        }
    }
}
