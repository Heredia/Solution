using System;

namespace Facade
{
    internal class Facade
    {
        private readonly OtherSystemA _otherSystemA;
        private readonly OtherSystemB _otherSystemB;

        public Facade()
        {
            _otherSystemA = new OtherSystemA();
            _otherSystemB = new OtherSystemB();
        }

        public void Method1()
        {
            Console.WriteLine("Facade.Method1()");
            _otherSystemA.Method1();
            Console.WriteLine(string.Empty);
        }

        public void Method2()
        {
            Console.WriteLine("Facade.Method2()");
            _otherSystemA.Method1();
            _otherSystemB.Method2();
            Console.WriteLine(string.Empty);
        }
    }
}