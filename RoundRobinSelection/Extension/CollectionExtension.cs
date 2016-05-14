using System;
using System.Collections.Generic;
using System.Linq;

namespace RoundRobinSelection.Extension
{
    public static class CollectionExtension
    {
        public static Tuple<T, int> SelectByRoundRobin<T, TResult>(this IEnumerable<T> collection, Func<T, TResult> orderByExpression, int? lastSelectedIndex)

        {
            var orderedCollection = collection.OrderBy(orderByExpression);

            if (!lastSelectedIndex.HasValue || lastSelectedIndex < 0 || lastSelectedIndex >= orderedCollection.Count() - 1)
            {
                return Tuple.Create(orderedCollection.ElementAtOrDefault(0), 0);
            }

            return Tuple.Create(orderedCollection.ElementAtOrDefault(lastSelectedIndex.Value + 1), lastSelectedIndex.Value + 1);
        }

        public static T SelectByRoundRobinFromPriorElement<T, TResult>(this IEnumerable<T> collection, Func<T, TResult> orderByExpression, T lastSelectedValue)

        {
            var orderedCollection = collection.OrderBy(orderByExpression);

            if (lastSelectedValue == null)
            {
                return orderedCollection.ElementAtOrDefault(0);
            }

            int lastSelectedIndex = orderedCollection.ToList().IndexOf(lastSelectedValue);

            if (lastSelectedIndex == orderedCollection.Count() - 1)
            {
                return orderedCollection.ElementAtOrDefault(0);
            }

            return orderedCollection.ElementAtOrDefault(++lastSelectedIndex);
        }
    }
}
