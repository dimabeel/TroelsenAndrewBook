using System;
using System.Collections.Generic;
using System.Text;

namespace Troelsen
{
    partial class Serialization
    {
        public interface IRadio
        {

        }

        [Serializable]
        public abstract class Radio : IRadio
        {
            public Radio()
            {
                MusicTypes = new List<string>();
                RadioTypes = new List<string>();
            }

            public List<string> RadioTypes { get; set; }

            public bool CanPlayRadio { get; set; }

            public bool SupportBluetooth { get; set; }

            public List<string> MusicTypes { get; set; }
        }
    }
}
