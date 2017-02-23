namespace Mediator
{
    internal abstract class Colleague
    {
        protected Mediator Mediator;

        protected Colleague(Mediator mediator)
        {
            Mediator = mediator;
        }
    }
}