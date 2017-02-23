using Helper.Values;

namespace Helper.Collections
{
    public class PagedListParameters
    {
        public Filter Filter { get; set; }

        public Order Order { get; set; }

        public Page Page { get; set; }
    }
}