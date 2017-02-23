using System;

namespace ChainOfResponsibility
{
    internal class ConcreteHandlerC : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 20 && request < 30)
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