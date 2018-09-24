using System;
using System.Collections.Generic;
using System.Linq;
using SmartSorting.Structure;

namespace SmartSorting.Algorithms
{
    /// <summary>
    /// The bubble sort compares each element in an array with the following element and uses an 
    /// auxiliary variable to exchange the elements' positions if the first value is bigger than the
    /// second one (for ascending order), or if the first value is smaller than the second one (for descending order).
    /// </summary>
    public class BubbleSort<T> : SortAlgorithm<T> where T : IComparable<T>
    {
        private Dictionary<ESortOrder, Func<T[], int, int, bool>> arrayCompareMethodDictionary;

        public BubbleSort()
        {
            this.arrayCompareMethodDictionary = new Dictionary<ESortOrder, Func<T[], int, int, bool>>();
            this.arrayCompareMethodDictionary.Add(ESortOrder.Descending, ValueInFistIndexIsBiggerThanValueInSecondIndex);
            this.arrayCompareMethodDictionary.Add(ESortOrder.Ascending, ValueInFistIndexIsSmallerThanValueInSecondIndex);
        }

        public override T[] Sort(T[] array, ESortOrder sortOrder = ESortOrder.Ascending)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (this.arrayCompareMethodDictionary[sortOrder](array, i, j))
                    {
                        T currentValueForFirstPosition = array[i];
                        array[i] = array[j];
                        array[j] = currentValueForFirstPosition;
                    }
                }
            }

            return array;
        }


        private bool ValueInFistIndexIsBiggerThanValueInSecondIndex(T[] array, int firstIndex, int secondIndex)
        {
            return array[firstIndex].CompareTo(array[secondIndex]) > 0;
        }


        private bool ValueInFistIndexIsSmallerThanValueInSecondIndex(T[] array, int firstIndex, int secondIndex)
        {
            return array[firstIndex].CompareTo(array[secondIndex]) < 0;
        }
    }
}