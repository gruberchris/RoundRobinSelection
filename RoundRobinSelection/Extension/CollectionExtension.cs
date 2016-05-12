using System;
using System.Collections.Generic;
using System.Linq;

namespace RoundRobinSelection.Extension
{
    public static class CollectionExtension
    {
        public static Tuple<T, int> RoundRobin<T>(this IEnumerable<T> collection, Func<T, object> orderByExpression, int lastSelectedIndex)

        {
            var orderedCollection = collection.OrderBy(orderByExpression);

            if (lastSelectedIndex < 0 || lastSelectedIndex >= orderedCollection.Count() - 1)
            {
                return Tuple.Create(orderedCollection.ElementAtOrDefault(0), 0);
            }

            return Tuple.Create(orderedCollection.ElementAtOrDefault(lastSelectedIndex + 1), lastSelectedIndex + 1);
        }
    }
}
