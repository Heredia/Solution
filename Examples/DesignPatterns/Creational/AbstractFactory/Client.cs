namespace AbstractFactory
{
    internal class Client
    {
        private readonly AbstractProductA _abstractProductA;
        private readonly AbstractProductB _abstractProductB;

        public Client(AbstractFactory abstractFactory)
        {
            _abstractProductB = abstractFactory.CreateProductB();
            _abstractProductA = abstractFactory.CreateProductA();
        }

        public void Run()
        {
            _abstractProductB.Interact(_abstractProductA);
        }
    }
}