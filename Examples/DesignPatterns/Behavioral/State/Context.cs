using System;

namespace State
{
    internal class Context
    {
        private State _state;

        public State State
        {
            get { return _state; }
            set
            {
                _state = value;
                Console.WriteLine("State: " + _state.GetType().Name);
            }
        }

        public Context(State state)
        {
            State = state;
        }

        public void Request()
        {
            _state.Handle(this);
        }
    }
}