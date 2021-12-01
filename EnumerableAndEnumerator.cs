using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Troelsen
{
    class EnumerableAndEnumerator
    {
        public static void Test()
        {
            var garage = new Garage();
            garage.Cars.Add(new Car("Ford", 1000));
            garage.Cars.Add(new Car("Audi", 3000));
            garage.Cars.Add(new Car("VW", 2000));
            garage.Cars.Add(new Car("Lexus", 4000));

            foreach(Car car in garage)
            {
                Console.WriteLine($"Car: {car.Name}, price: {car.Price}$");
            }
        }

        class Car
        {
            public Car(string name, int price)
            {
                Name = name;
                Price = price;
            }

            public string Name { get; set; }

            public int Price { get; set; }
        }

        class Garage : IEnumerable
        {
            public Garage() { cars = new List<Car>(); }

            public IEnumerator GetEnumerator()
            {
                foreach(Car c in Cars)
                {
                    yield return c;
                }
            }

            public List<Car> Cars
            {
                get
                {
                    return cars;
                }
            }

            private List<Car> cars;
        }
    }
}
