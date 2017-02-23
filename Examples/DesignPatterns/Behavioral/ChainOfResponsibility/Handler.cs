namespace ChainOfResponsibility
{
    internal abstract class Handler
    {
        protected Handler Successor;

        public void SetSuccessor(Handler successor)
        {
            Successor = successor;
        }

        public abstract void HandleRequest(int request);
    }
}