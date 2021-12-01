using System;
using System.Collections.Generic;
using System.Text;

namespace Troelsen
{
    partial class Serialization
    {
        public interface ICar
        {

        }

        [Serializable]
        public class Car : ICar
        {
            public Car()
            {
                seat = new List<ISeat>();
            }

            public IRadio Radio { get; set; }

            public IEngine Engine { get; set; }

            public ISuspension Suspension { get; set; }

            public List<ISeat> Seats { get; set; }

            IRadio radio;
            IEngine engine;
            ISuspension suspension;
            List<ISeat> seat;
        }
    }
}
