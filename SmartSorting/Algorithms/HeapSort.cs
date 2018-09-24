using System;
using System.Collections.Generic;
using SmartSorting.Structure;

namespace SmartSorting.Algorithms
{
    /// <summary>
    /// This algorithm uses a heap structure to sort the array.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HeapSort<T> : SortAlgorithm<T> where T : IComparable<T>
    {
        private Dictionary<ESortOrder, Func<T[], int, bool>> arrayElementsCompareMethodDictionary;
        private Dictionary<ESortOrder, Func<T[], int, T, bool>> tempToArrayCompareMethodDictionary;

        public HeapSort()
        {
            this.arrayElementsCompareMethodDictionary = new Dictionary<ESortOrder, Func<T[], int, bool>>();
            this.tempToArrayCompareMethodDictionary = new Dictionary<ESortOrder, Func<T[], int, T, bool>>();

            this.arrayElementsCompareMethodDictionary.Add(ESortOrder.Ascending, CurrentElementIsSmallerThanNextElement);
            this.arrayElementsCompareMethodDictionary.Add(ESortOrder.Descending, CurrentElementIsBiggerThanNextElement);

            this.tempToArrayCompareMethodDictionary.Add(ESortOrder.Ascending, TempValueIsSmallerThanCurrentElement);
            this.tempToArrayCompareMethodDictionary.Add(ESortOrder.Descending, TempValueIsBiggerThanCurrentElement);
        }

        public override T[] Sort(T[] array, ESortOrder sortOrder = ESortOrder.Ascending)
        {
            ExecuteHeapSort(array, array.Length, sortOrder);
            return array;
        }

        private void ExecuteHeapSort(T[] array, int position, ESortOrder sortOrder)
        {
            int index;
            T tempValue;

            for (index = (position - 1) / 2; index >= 0; index--)
            {
                CreateHeap(array, index, position - 1, sortOrder);
            }

            for (index = position - 1; index >= 1; index--)
            {
                tempValue = array[0];
                array[0] = array[index];
                array[index] = tempValue;
                CreateHeap(array, 0, index - 1, sortOrder);
            }
        }

        private void CreateHeap(T[] array, int startPosition, int endPosition, ESortOrder sortOrder)
        {
            T tempValue = array[startPosition];
            int smallestHeapPosition = (startPosition * 2) + 1;

            bool isComparisonSatisfied;

            // While in array
            while (smallestHeapPosition <= endPosition)
            {
                // Does the father element has two children? 
                if (smallestHeapPosition < endPosition)
                {
                    isComparisonSatisfied = this.arrayElementsCompareMethodDictionary[sortOrder](array, smallestHeapPosition);

                    // Which element is the biggest one?
                    if (isComparisonSatisfied)
                    {
                        smallestHeapPosition += 1;
                    }
                }

                isComparisonSatisfied = this.tempToArrayCompareMethodDictionary[sortOrder](array, smallestHeapPosition, tempValue);
                if (isComparisonSatisfied)
                {
                    array[startPosition] = array[smallestHeapPosition];
                    startPosition = smallestHeapPosition;
                    smallestHeapPosition = (2 * startPosition) + 1;
                }
                else
                {
                    smallestHeapPosition = endPosition + 1;
                }
            }
            array[startPosition] = tempValue; // Old father element exchanges its position with the last analyzed child
        }

        private bool CurrentElementIsSmallerThanNextElement(T[] array, int index)
        {
            return array[index].CompareTo(array[index + 1]) < 0;
        }

        private bool CurrentElementIsBiggerThanNextElement(T[] array, int index)
        {
            return array[index].CompareTo(array[index + 1]) > 0;
        }

        private bool TempValueIsSmallerThanCurrentElement(T[] array, int index, T tempValue)
        {
            return tempValue.CompareTo(array[index]) < 0;
        }

        private bool TempValueIsBiggerThanCurrentElement(T[] array, int index, T tempValue)
        {
            return tempValue.CompareTo(array[index]) > 0;
        }
    }
}