namespace Builder
{
    internal abstract class Builder
    {
        public abstract void BuildPart1();

        public abstract void BuildPart2();

        public abstract Product GetResult();
    }
}