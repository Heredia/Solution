using System.Collections.Generic;
using System.Linq;

namespace Helper.Collections
{
    public class PagedList<T>
    {
        public PagedList(IQueryable<T> queryable, PagedListParameters parameters)
        {
            Parameters = parameters;

            if (queryable == null) { return; }

            if (parameters?.Filter != null)
            {
                queryable = queryable.Filter(parameters.Filter.Property, parameters.Filter.Condition, parameters.Filter.Value);
            }

            if (queryable == null) { return; }

            Count = queryable.Count();

            if (parameters?.Order == null || parameters.Page == null)
                List = queryable.AsEnumerable();
            else
                List = queryable
                    .Order(parameters.Order.Property, parameters.Order.IsAscending)
                    .Page(parameters.Page.Index, parameters.Page.Size)
                    .AsEnumerable();
        }

        public long Count { get; private set; }

        public IEnumerable<T> List { get; private set; }

        public PagedListParameters Parameters { get; private set; }
    }
}