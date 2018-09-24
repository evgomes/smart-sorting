using System;
using System.Collections.Generic;
using SmartSorting.Structure;

namespace SmartSorting.Algorithms
{
    /// <summary>
    /// This algorithm uses a cursor to compare the current item with all values on its left side, intenting 
    /// to sort only positions that weren't checked yet.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class InsertionSort<T> : SortAlgorithm<T> where T : IComparable<T>
    {
        private Dictionary<ESortOrder, Func<T[], int, bool>> arrayCompareMethodDictionary;

        public InsertionSort()
        {
            this.arrayCompareMethodDictionary = new Dictionary<ESortOrder, Func<T[], int, bool>>();
            this.arrayCompareMethodDictionary.Add(ESortOrder.Ascending, PreviousValueIsSmallerThanFollowingValue);
            this.arrayCompareMethodDictionary.Add(ESortOrder.Descending, PreviousValueIsBiggerThanFollowingValue);
        }

        public override T[] Sort(T[] array, ESortOrder sortOrder = ESortOrder.Ascending)
        {
            int cursor = 1;
            int currentPosition = cursor;

            // First for goes throught the array starting by the cursor position
            for (int i = cursor; i <= array.Length; i++)
            {
                currentPosition = cursor - 1;

                // While the actual number (cursor) is smaller than or equals array[0], keeps comparing 
                for (int j = currentPosition; j > 0; j--)
                {
                    if (this.arrayCompareMethodDictionary[sortOrder](array, j))
                    {
                        T currentValueForSecondPosition = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = currentValueForSecondPosition;
                    }
                }
                cursor++;
            }

            return array;
        }

        private bool PreviousValueIsBiggerThanFollowingValue(T[] array, int index)
        {
            return array[index].CompareTo(array[index - 1]) > 0;
        }


        private bool PreviousValueIsSmallerThanFollowingValue(T[] array, int index)
        {
            return array[index].CompareTo(array[index - 1]) < 0;
        }
    }
}