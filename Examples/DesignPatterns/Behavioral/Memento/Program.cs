using System;

namespace Memento
{
    internal class Program
    {
        private static void Main()
        {
            var originator = new Originator { State = "On" };

            var caretaker = new Caretaker { Memento = originator.CreateMemento() };

            originator.State = "Off";

            originator.SetMemento(caretaker.Memento);

            Console.ReadKey();
        }
    }
}