using System;
using System.Collections.Generic;
using System.Text;

namespace Troelsen
{
    public class DelegatesAndEvents
    {

        public static void Test()
        {
            TestEvent();
            TestDelegate();
            TestGenericDelegate();
        }

        #region TestEvent
        private static void TestEvent()
        {
            var instance = new DelegatesAndEvents();
            //instance.testEvent = instance.PrintSmth; //test ? operator
            instance.testEvent += ((object sender, EventArgs args) => Console.WriteLine("Haha"));
            instance.testEvent +=
                ((object sender, EventArgs args) =>
                {
                    Console.WriteLine("Lol");
                    Console.WriteLine("Bomb");
                });

            instance.testEvent?.Invoke(instance, EventArgs.Empty);
        }

        delegate void EventHandlerDelegate(object sender, EventArgs args);

        event EventHandlerDelegate testEvent;
        #endregion

        #region TestDelegate
        private static void TestDelegate()
        {
            var instance = new DelegatesAndEvents();
            instance.eventHandlerDelegate = instance.PrintSmth;
            instance.eventHandlerDelegate.Invoke(instance, EventArgs.Empty);
        }

        Action<object, EventArgs> eventHandlerDelegate;
        #endregion

        #region GenericDelegate
        private static void TestGenericDelegate()
        {
            var instance = new DelegatesAndEvents();
            instance.genericDelegateEvent = instance.PrintSmth;
            instance.genericDelegateEvent.Invoke(instance, EventArgs.Empty);
        }

        event EventHandler<EventArgs> genericDelegateEvent;

        #endregion

        public void PrintSmth(object sender, EventArgs arg)
        {
            Console.WriteLine("Kek");
        }
    }
}
