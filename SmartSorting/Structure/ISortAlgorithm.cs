using System;
using System.Collections.Generic;

namespace SmartSorting.Structure
{
    /// <summary>
	/// Defines the contract of a sort algorithm.
	/// </summary>
	public interface ISortAlgorithm<T> where T : IComparable<T>
	{
		/// <summary>
		/// Sorts an array accourding to a determined order.
		/// </summary>
		/// <typeparam name="T">Type of items in array.</typeparam>
		/// <param name="array">Array to sort.</param>
		/// <param name="sortOrder">Ascending or descending order.</param>
		/// <returns>Sorted array.</returns>
		T[] Sort(T[] array, ESortOrder sortOrder = ESortOrder.Ascending);


		/// <summary>
		/// Sorts an enumerable accourding to a determined order.
		/// </summary>
		/// <typeparam name="T">Type of items in array.</typeparam>
		/// <param name="enumerable">Enumerable to sort.</param>
		/// <param name="sortOrder">Ascending or descending order.</param>
		/// <returns>Sorted enumerable.</returns>
		IEnumerable<T> Sort(IEnumerable<T> enumerable, ESortOrder sortOrder = ESortOrder.Ascending);
	}
}