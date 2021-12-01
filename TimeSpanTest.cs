using System;
using System.Collections.Generic;
using System.Text;

namespace Troelsen
{
    class TimeSpanTest
    {

        public static void Test()
        {
            var timeSpan = new TimeSpan(5, 10, 7, 4, 200);
            Test(timeSpan);
            Console.ReadKey();
            timeSpan = timeSpan.Add(new TimeSpan(1, 0, 0, 0, 0));
            Test(timeSpan);

            var date1 = new DateTime(2019, 10, 10, 10, 10, 10);
            var date2 = new DateTime(2020, 02, 02, 02, 02, 02);
            TimeSpan span = date2 - date1;
            Test(span);
        }

        public static void Test(TimeSpan timeSpan)
        {
            Console.WriteLine($"total days: {timeSpan.TotalDays}");
            Console.WriteLine($"total hours: {timeSpan.TotalHours}");
            Console.WriteLine($"total minutes: {timeSpan.TotalMinutes}");
            Console.WriteLine($"total seconds: {timeSpan.TotalSeconds}");
            Console.WriteLine($"total milliseconds: {timeSpan.TotalMilliseconds}");
            Console.WriteLine($"{new string('-', 10)}");
            Console.WriteLine($"days: {timeSpan.Days}");
            Console.WriteLine($"hours: {timeSpan.Hours}");
            Console.WriteLine($"minutes: {timeSpan.Minutes}");
            Console.WriteLine($"seconds: {timeSpan.Seconds}");
            Console.WriteLine($"milliseconds: {timeSpan.Milliseconds}");
            Console.WriteLine($"ticks: {timeSpan.Ticks}");
            Console.WriteLine($"{new string('*', 10)}");
        }

    }
}
