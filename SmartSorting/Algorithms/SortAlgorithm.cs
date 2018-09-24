using System;
using System.Collections.Generic;
using System.Linq;
using SmartSorting.Structure;

namespace SmartSorting.Algorithms
{
    public abstract class SortAlgorithm<T> : ISortAlgorithm<T> where T : IComparable<T>
    {
        public virtual IEnumerable<T> Sort(IEnumerable<T> enumerable, ESortOrder sortOrder = ESortOrder.Ascending)
        {
            var array = enumerable.ToArray();
            return Sort(array, sortOrder).AsEnumerable();
        }

        public abstract T[] Sort(T[] array, ESortOrder sortOrder = ESortOrder.Ascending);
    }
}