using Helper.Enums;

namespace Helper.Values
{
    public class Filter
    {
        public Condition Condition { get; set; }

        public string Property { get; set; }

        public object Value { get; set; }
    }
}