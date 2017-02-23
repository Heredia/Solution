using System;

namespace Observer
{
    internal class Program
    {
        private static void Main()
        {
            var concreteSubject = new ConcreteSubject();

            concreteSubject.Attach(new ConcreteObserver(concreteSubject, "X"));
            concreteSubject.Attach(new ConcreteObserver(concreteSubject, "Y"));
            concreteSubject.Attach(new ConcreteObserver(concreteSubject, "Z"));

            concreteSubject.SubjectState = "ABC";
            concreteSubject.Notify();

            Console.ReadKey();
        }
    }
}