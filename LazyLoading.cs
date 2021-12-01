using System;
using System.Collections.Generic;
using System.Text;

namespace Troelsen
{
    class LazyLoading
    {
        public static void Test()
        {
            Reader reader = new Reader();
            reader.ReadEbook();
            reader.ReadBook();
        }
    }

    class Reader
    {
        // If we have more than zero arguments in constructor
        //Lazy<Library> library = new Lazy<Library>( () => new Library(args));
        Lazy<Library> library = new Lazy<Library>();

        public void ReadBook()
        {
            library.Value.GetBook();
            Console.WriteLine("Читаем бумажную книгу");
        }

        public void ReadEbook()
        {
            Console.WriteLine("Читаем книгу на компьютере");
        }
    }

    class Library
    {
        private string[] books = new string[99];

        public void GetBook()
        {
            Console.WriteLine("Выдаем книгу читателю");
        }
    }
}
