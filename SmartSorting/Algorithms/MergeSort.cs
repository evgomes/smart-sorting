using System;
using System.Collections.Generic;
using SmartSorting.Structure;

namespace SmartSorting.Algorithms
{
    /// <summary>
    /// This algorithm uses a "divide to conquer" strategy to sort arrays.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MergeSort<T> : SortAlgorithm<T> where T : IComparable<T>
    {
        private Dictionary<ESortOrder, Func<T[], int, int, bool>> arrayCompareMethodDictionary;

        public MergeSort()
        {
            this.arrayCompareMethodDictionary = new Dictionary<ESortOrder, Func<T[], int, int, bool>>();

            this.arrayCompareMethodDictionary.Add(ESortOrder.Ascending, IsLeftValueSmallerThanRightValue);
            this.arrayCompareMethodDictionary.Add(ESortOrder.Descending, IsLeftValueBiggerThanRightValue);
        }

        public override T[] Sort(T[] array, ESortOrder sortOrder = ESortOrder.Ascending)
        {
            T[] auxiliarArray = new T[array.Length];
            ExecuteMerge(array, auxiliarArray, 0, array.Length, sortOrder);
            return array;
        }

        private void ExecuteMerge(T[] array, T[] auxiliarArray, int startPosition, int endPosition, ESortOrder sortOrder)
        {
            if ((endPosition - startPosition) < 2)
                return;

            int middlePosition = ((startPosition + endPosition) / 2);

            ExecuteMerge(array, auxiliarArray, startPosition, middlePosition, sortOrder);
            ExecuteMerge(array, auxiliarArray, middlePosition, endPosition, sortOrder);
            Join(array, auxiliarArray, startPosition, middlePosition, endPosition, sortOrder);
        }

        private void Join(T[] array, T[] auxiliarArray, int startPosition, int middlePosition, int endPosition, ESortOrder sortOrder)
        {
            int left = startPosition;
            int right = middlePosition;

            for (int i = startPosition; i < endPosition; ++i)
            {
                if ((left < middlePosition) && ((right >= endPosition) || (this.arrayCompareMethodDictionary[sortOrder](array, left, right))))
                {
                    auxiliarArray[i] = array[left];
                    ++left;
                }
                else
                {
                    auxiliarArray[i] = array[right];
                    ++right;
                }
            }

            // Copying back the array
            for (int i = startPosition; i < endPosition; ++i)
            {
                array[i] = auxiliarArray[i];
            }
        }

        private bool IsLeftValueSmallerThanRightValue(T[] array, int leftPositon, int rightPosition)
        {
            return array[leftPositon].CompareTo(array[rightPosition]) < 0;
        }

        private bool IsLeftValueBiggerThanRightValue(T[] array, int leftPositon, int rightPosition)
        {
            return array[leftPositon].CompareTo(array[rightPosition]) > 0;
        }
    }
}