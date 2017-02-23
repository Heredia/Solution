namespace Prototype
{
    internal class ConcretePrototypeA : Prototype
    {
        public ConcretePrototypeA(string id) : base(id)
        {
        }

        public override Prototype Clone()
        {
            return (Prototype)MemberwiseClone();
        }
    }
}