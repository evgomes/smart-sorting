using System;
using SmartSorting.Algorithms;

namespace SmartSorting.Structure
{
    /// <summary>
    /// Creates instances of sort algorithms.
    /// </summary>
	public static class SortAlgotithmFactory
	{
		/// <summary>
		/// Returns a sort algorithm.
		/// </summary>
		/// <param name="sortAlgorithm">Desired algorithm.</param>
		/// <returns>Sort algorithm.</returns>
		public static ISortAlgorithm<T> Get<T>(ESortAlgorithm sortAlgorithm) where T : IComparable<T>
		{
			switch(sortAlgorithm)
			{
				case ESortAlgorithm.BubbleSort:
					return new BubbleSort<T>();
				case ESortAlgorithm.InsertionSort:
					return new InsertionSort<T>();
				case ESortAlgorithm.SelectionSort:
					return new SelectionSort<T>();
				case ESortAlgorithm.QuickSort:
					return new QuickSort<T>();
				case ESortAlgorithm.HeapSort:
					return new HeapSort<T>();
				case ESortAlgorithm.MergeSort:
					return new MergeSort<T>();
				default:
					throw new NotImplementedException(nameof(ESortAlgorithm));
			}
		}
	}
}