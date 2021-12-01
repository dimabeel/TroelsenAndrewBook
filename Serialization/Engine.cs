using System;
using System.Collections.Generic;
using System.Text;

namespace Troelsen
{
    partial class Serialization
    {
        public interface IEngine
        {

        }

        [Serializable]
        public abstract class Engine : IEngine
        {

        }
    }
}
