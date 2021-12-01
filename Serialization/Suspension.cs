using System;
using System.Collections.Generic;
using System.Text;

namespace Troelsen
{
    partial class Serialization
    {
        public interface ISuspension
        {

        }

        [Serializable]
        public abstract class Suspension : ISuspension
        {
            public Suspension() { }

            public string Type { get; set; }

            public int WheelsCount { get; set; }
        }
    }
}
