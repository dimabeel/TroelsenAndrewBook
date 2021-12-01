using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Troelsen
{
    class IOFileWatcher
    {
        public static void Test()
        {
            File.WriteAllText(".test.txt", "");

            var watcher = new FileSystemWatcher();
            watcher.Path = ".";
            watcher.NotifyFilter = NotifyFilters.LastWrite |
                NotifyFilters.FileName |
                NotifyFilters.DirectoryName |
                NotifyFilters.Size |
                NotifyFilters.LastWrite |
                NotifyFilters.CreationTime;
            watcher.Filter = "*.txt";
            watcher.EnableRaisingEvents = true;
            watcher.Created += FileCreated;
            watcher.Changed += FileChanged;
            watcher.Deleted += FileDeleted;
            watcher.Renamed += FileRenamed;
            watcher.Error += FileError;

            while (Console.ReadLine() != "Q")
            {
                string result = Console.ReadLine();

            }
         }

        public static void FileRenamed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File was renamed");
        }

        public static void FileCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File was created");
        }

        public static void FileChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File was changed");
        }

        public static void FileDeleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File was deleted");
        }

        public static void FileError(object sender, ErrorEventArgs e)
        {
            Console.WriteLine("File was error");
        }
    }
}
