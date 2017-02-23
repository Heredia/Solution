using FastMapper;

namespace Helper.Mapping
{
    public static class MappingHelper
    {
        public static TResult Map<TResult>(object source)
        {
            return TypeAdapter.Adapt<TResult>(source);
        }
    }
}