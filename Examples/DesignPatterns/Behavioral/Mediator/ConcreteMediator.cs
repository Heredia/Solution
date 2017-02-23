namespace Mediator
{
    internal class ConcreteMediator : Mediator
    {
        private ConcreteColleagueA _colleagueA;
        private ConcreteColleagueB _colleagueB;

        public ConcreteColleagueA ColleagueA { set { _colleagueA = value; } }
        public ConcreteColleagueB ColleagueB { set { _colleagueB = value; } }

        public override void Send(string message, Colleague colleague)
        {
            if (colleague == _colleagueA)
            {
                _colleagueB.Notify(message);
            }
            else
            {
                _colleagueA.Notify(message);
            }
        }
    }
}