using System;

namespace Proxy
{
    internal class RealSubject : Subject
    {
        public override void Request()
        {
            Console.WriteLine("RealSubject.Request()");
        }
    }
}