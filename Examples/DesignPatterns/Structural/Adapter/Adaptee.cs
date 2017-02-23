using System;

namespace Adapter
{
    internal class Adaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("Called Adaptee SpecificRequest()");
        }
    }
}