using System.Collections.Generic;
using System.Linq;

namespace RoundRobinSelection
{
    public static class ArrayHelper
    {
        public static T SelectByRoundRobin<T>(IEnumerable<T> collection, int lastSelectedIndex)
        {
            var orderedCollection = collection.OrderBy(element => element);

            if (lastSelectedIndex < 0 || lastSelectedIndex >= orderedCollection.Count() - 1)
            {
                return orderedCollection.ElementAtOrDefault(0);
            }

            return orderedCollection.ElementAtOrDefault(lastSelectedIndex + 1);
        }
    }
}
