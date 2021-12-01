using System;
using System.Collections.Generic;
using System.Text;

namespace Troelsen
{
    partial class Serialization
    {
        public interface ISeat
        {

        }

        public abstract class Seat : ISeat
        {
            public Seat() 
            {
                Options = new List<string>();
            }

            public string Material { get; set; }

            public List<string> Options { get; set; }
        }

        public class LeatherSeat : Seat
        {
            public LeatherSeat() : base()
            {
                Material = "Leather";
                Options.Add("Подогрев");
                Options.Add("Перфорация");
                Options.Add("Поясничная поддержка");
            }
        }

        public class FabricSeat : Seat
        {
            public FabricSeat() : base()
            {
                Material = "Fabric";
                Options.Add("Подогрев");
            }
        }
    }

}
