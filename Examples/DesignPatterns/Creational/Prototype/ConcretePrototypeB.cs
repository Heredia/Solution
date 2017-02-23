namespace Prototype
{
    internal class ConcretePrototypeB : Prototype
    {
        public ConcretePrototypeB(string id) : base(id)
        {
        }

        public override Prototype Clone()
        {
            return (Prototype)MemberwiseClone();
        }
    }
}