using System;
using System.Collections.Generic;
using System.Text;

namespace Troelsen
{
    public static class ValueTypeAndReferenceType
    {
        public static void Test()
        {
            var person = new Person("Dzmitri", 22);
            PrintPerson(person);
            MaximizeAge(person);
            PrintPerson(person);
            RefreshPerson(ref person);
            PrintPerson(person);
        }

        private static void PrintPerson(Person person)
        {
            Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
            Console.WriteLine($"Hash: " + person.GetHashCode());
        }

        private static void MaximizeAge(Person person)
        {
            person.Age = 99;
        }

        private static void RefreshPerson(ref Person person)
        {
            person = new Person("Undefined", 0);
        }

        private class Person
        {
            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public int Age { get; set; }

            public string Name { get; set; }
        }
    }
}
