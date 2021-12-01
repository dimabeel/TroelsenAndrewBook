using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Troelsen
{
    partial class Serialization
    {
        public static void Test()
        {
            bool infiniteLoop = true;
            const string exitChar = "Q";
            const string serializeChar = "S";
            const string deserializeChar = "D";
            while(infiniteLoop)
            {
                string result = Console.ReadLine();
                switch(result)
                {
                    case exitChar:
                        infiniteLoop = false;
                        break;

                    case serializeChar:
                        ObjectModel.GetInstance().Serialize();
                        break;

                    case deserializeChar:
                        ObjectModel.GetInstance().Deserialize();
                        break;
                }
            }
        }

        /// <summary>
        /// Оболочка для управления сериализацией
        /// </summary>
        public class ObjectModel
        {
            private ObjectModel()
            {
                cars = new List<ICar>();
            }

            public void Serialize()
            {

            }

            public void Deserialize()
            {

            }

            public static ObjectModel GetInstance()
            {
                if(objectModel == null)
                {
                    objectModel = new ObjectModel();
                }

                return objectModel;
            }

            private static ObjectModel objectModel;

            public List<ICar> cars;
        }
    }
}
