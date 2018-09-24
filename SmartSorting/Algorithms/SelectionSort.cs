using System;
using System.Collections.Generic;
using SmartSorting.Structure;

namespace SmartSorting.Algorithms
{
    /// <summary>
    /// The selection sort uses a cursor to verify the biggest or smallest value at the right side of 
    /// the current item to exchange positions.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SelectionSort<T> : SortAlgorithm<T> where T : IComparable<T>
    {
        private Dictionary<ESortOrder, Func<T[], int, T, bool>> arrayCompareMethodDictionary;

        public SelectionSort()
        {
            this.arrayCompareMethodDictionary = new Dictionary<ESortOrder, Func<T[], int, T, bool>>();
            this.arrayCompareMethodDictionary.Add(ESortOrder.Ascending, ItemInCurrentPositionIsSmallerThanCurrentSmallestValue);
            this.arrayCompareMethodDictionary.Add(ESortOrder.Descending, ItemInCurrentPositionIsBiggerThanCurrentSmallestValue);
        }

        public override T[] Sort(T[] array, ESortOrder sortOrder = ESortOrder.Ascending)
        {
            T smallestValue;
            int smallestValuePosition = 0;

            for (int i = 0; i < array.Length; i++)
            {
                smallestValue = array[i];
                smallestValuePosition = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (this.arrayCompareMethodDictionary[sortOrder](array, j, smallestValue))
                    {
                        smallestValue = array[j];
                        smallestValuePosition = j;
                    }
                }

                array[smallestValuePosition] = array[i];
                array[i] = smallestValue;
            }

            return array;
        }

        private bool ItemInCurrentPositionIsSmallerThanCurrentSmallestValue(T[] array, int currentPosition, T smallestValue)
        {
            return array[currentPosition].CompareTo(smallestValue) < 0;
        }

        private bool ItemInCurrentPositionIsBiggerThanCurrentSmallestValue(T[] array, int currentPosition, T smallestValue)
        {
            return array[currentPosition].CompareTo(smallestValue) > 0;
        }
    }
}