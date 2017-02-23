using System;

namespace ChainOfResponsibility
{
    internal class ConcreteHandlerA : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 0 && request < 10)
            {
                Console.WriteLine($"{GetType().Name} handled request {request}");
            }
            else
            {
                Successor?.HandleRequest(request);
            }
        }
    }
}