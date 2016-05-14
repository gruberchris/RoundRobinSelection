using System;
using System.Collections.Generic;
using System.Linq;

namespace RoundRobinSelection.Extension
{
    public static class CollectionExtension
    {
        public static Tuple<T, int> RoundRobin<T, TResult>(this IEnumerable<T> collection, Func<T, TResult> orderByExpression, int? lastSelectedIndex)

        {
            var orderedCollection = collection.OrderBy(orderByExpression);

            if (!lastSelectedIndex.HasValue || lastSelectedIndex < 0 || lastSelectedIndex >= orderedCollection.Count() - 1)
            {
                return Tuple.Create(orderedCollection.ElementAtOrDefault(0), 0);
            }

            return Tuple.Create(orderedCollection.ElementAtOrDefault(lastSelectedIndex.Value + 1), lastSelectedIndex.Value + 1);
        }
    }
}
