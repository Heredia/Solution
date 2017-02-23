namespace Builder
{
    internal class ConcreteBuilderB : Builder
    {
        private readonly Product _product = new Product();

        public override void BuildPart1()
        {
            _product.Add("ConcreteBuilderB build part1");
        }

        public override void BuildPart2()
        {
            _product.Add("ConcreteBuilderB build part2");
        }

        public override Product GetResult()
        {
            return _product;
        }
    }
}