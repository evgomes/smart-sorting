using System;
using System.Collections.Generic;
using SmartSorting.Structure;

namespace SmartSorting.Algorithms
{
    /// <summary>
    /// The quick sort uses a pivot to recursively sort all elements in an array's left and right sides.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QuickSort<T> : SortAlgorithm<T> where T : IComparable<T>
    {
        private Dictionary<ESortOrder, Func<T[], int, T, bool>> arrayToPivotCompareMethodDictionary;
        private Dictionary<ESortOrder, Func<T[], int, T, bool>> pivotToArrayCompareMethodDictionary;

        public QuickSort()
        {
            this.arrayToPivotCompareMethodDictionary = new Dictionary<ESortOrder, Func<T[], int, T, bool>>();
            this.pivotToArrayCompareMethodDictionary = new Dictionary<ESortOrder, Func<T[], int, T, bool>>();

            this.arrayToPivotCompareMethodDictionary.Add(ESortOrder.Ascending, CompareArrayToPivotForAscendingOrder);
            this.arrayToPivotCompareMethodDictionary.Add(ESortOrder.Descending, CompareArrayToPivotForDescendingOrder);

            this.pivotToArrayCompareMethodDictionary.Add(ESortOrder.Ascending, ComparePivotToArrayForAscendingOrder);
            this.pivotToArrayCompareMethodDictionary.Add(ESortOrder.Descending, ComparePivotToArrayForDescendingOrder);
        }

        public override T[] Sort(T[] array, ESortOrder sortOrder = ESortOrder.Ascending)
        {
            ExecuteQuickSort(array, 0, array.Length - 1, sortOrder);
            return array;
        }

        private void ExecuteQuickSort(T[] array, int startPosition, int endPosition, ESortOrder sortOrder)
        {
            if (startPosition < endPosition)
            {
                int pivotPosition = Split(array, startPosition, endPosition, sortOrder);
                ExecuteQuickSort(array, startPosition, pivotPosition - 1, sortOrder);
                ExecuteQuickSort(array, pivotPosition + 1, endPosition, sortOrder);
            }
        }

        private int Split(T[] array, int startPosition, int endPosition, ESortOrder sortOrder)
        {
            T pivotValue = array[startPosition];
            int i = startPosition + 1;
            int f = endPosition;

            while (i <= f)
            {
                bool arrayToPivotComparation = this.arrayToPivotCompareMethodDictionary[sortOrder](array, i, pivotValue);
                bool pivotToArrayComparation = this.pivotToArrayCompareMethodDictionary[sortOrder](array, f, pivotValue);

                if (arrayToPivotComparation)
                    i++;
                else if (pivotToArrayComparation)
                    f--;
                else
                {
                    T exchangeValue = array[i];
                    array[i] = array[f];
                    array[f] = exchangeValue;
                    i++;
                    f--;
                }
            }
            array[startPosition] = array[f];
            array[f] = pivotValue;
            return f;
        }

        private bool CompareArrayToPivotForAscendingOrder(T[] array, int index, T pivotValue)
        {
            return array[index].CompareTo(pivotValue) <= 0;
        }

        private bool CompareArrayToPivotForDescendingOrder(T[] array, int index, T pivotValue)
        {
            return array[index].CompareTo(pivotValue) >= 0;
        }

        private bool ComparePivotToArrayForAscendingOrder(T[] array, int index, T pivotValue)
        {
            return pivotValue.CompareTo(array[index]) < 0;
        }

        private bool ComparePivotToArrayForDescendingOrder(T[] array, int index, T pivotValue)
        {
            return pivotValue.CompareTo(array[index]) > 0;
        }
    }
}