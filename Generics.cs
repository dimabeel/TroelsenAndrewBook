using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;

namespace Troelsen
{
    public class Generics
    {
        public static void Test()
        {
            GenericComparableTest();
            ObservableCollectionTest();
            TestGenericSwap();
            GenericClassTest();
        }

        static void GenericComparableTest()
        {
            Animal myAnimal = new Animal("Dog", 4);
            List<Animal> animals = new List<Animal>()
            {
                new Animal("Horse", 10),
                new Animal("Cat", 5),
                new Animal("Fish", 7)
            };

            foreach (var animal in animals)
            {
                Console.WriteLine($"{myAnimal.CompareTo(animal)}");
            }
            Console.ReadKey();
        }

        static void ObservableCollectionTest()
        {
            var animals = new ObservableCollection<Animal>();
            animals.CollectionChanged += ObservableCollectionPrint;
            animals.Add(new Animal("Dog", 4));
            animals.Add(new Animal("Horse", 10));
            animals.RemoveAt(0);
            animals.Add(new Animal("Cat", 5));
            animals.RemoveAt(1);
            animals.Add(new Animal("Fish", 7));
            animals.Move(0, 1);
        }

        static void ObservableCollectionPrint(object sender,
            NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Console.WriteLine($"Added items:{e.NewItems.Count}.");
                    break;

                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine($"Removed items:{e.OldItems.Count}");
                    break;

                default:
                    Console.WriteLine("Happened any action");
                    break;
            }
        }

        static void TestGenericSwap()
        {
            string leftStr = "left";
            string rightStr = "right";
            Swap<string>(ref leftStr, ref rightStr);
            Console.WriteLine($"{leftStr}:{rightStr}");

            int leftInt = 0;
            int rightInt = 1;
            Swap<int>(ref leftInt, ref rightInt);
            Console.WriteLine($"{leftInt}:{rightInt}");
        }

        static void Swap<T>(ref T obj1, ref T obj2)
        {
            T temp = obj1;
            obj1 = obj2;
            obj2 = temp;
        }

        static void GenericClassTest()
        {
            var animalGeneric = new ClassInfo<Animal>();
            animalGeneric.Print();

            var intGeneric = new ClassInfo<int>();
            intGeneric.Print();

            var stringGeneric = new ClassInfo<string>();
            stringGeneric.Print();
        }

        class Animal : IComparable<Animal>
        {
            public Animal(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public string Name { get; set; }

            public int Age { get; set; }

            public int CompareTo(Animal animal)
            {
                if(Age > animal.Age)
                {
                    return 1;
                }
                
                if(Age < animal.Age)
                {
                    return -1;
                }

                return 0;
            }
        }

        class ClassInfo<T>
        {
            public ClassInfo()
            {
            }

            public void Print()
            {
                Console.WriteLine($"{typeof(T)}");
            }
        }
    }
}
