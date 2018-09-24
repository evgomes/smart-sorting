using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartSorting.Structure;

namespace SmartSorting.Extensions
{
    /// <summary>
    /// Extension methods for sorting arrays and enumerables.
    /// </summary>
    public static class SortableExtensions
    {
        /// <summary>
        /// Sorts an array using a specific sort algorithm.
        /// </summary>
        /// <param name="array">Array to sort.</param>
        /// <param name="sortAlgorithm">Sort algorithm.</param>
        /// <param name="sortOrder">Sort order.</param>
        /// <typeparam name="T">Type of items in array.</typeparam>
        public static void SortUsing<T>(this T[] array, ESortAlgorithm sortAlgorithm, ESortOrder sortOrder = ESortOrder.Ascending)
            where T : IComparable<T>
        {
            var algorithm = SortAlgotithmFactory.Get<T>(sortAlgorithm);
            algorithm.Sort(array, sortOrder);
        }

        /// <summary>
        /// Sorts an enumeration using a specific sort algorithm.
        /// </summary>
        /// <param name="array">Array to sort.</param>
        /// <param name="sortAlgorithm">Sort algorithm.</param>
        /// <param name="sortOrder">Sort order.</param>
        /// <typeparam name="T">Type of items in array.</typeparam>
        public static IEnumerable<T> SortUsing<T>(this IEnumerable<T> enumerable, ESortAlgorithm sortAlgorithm, ESortOrder sortOrder = ESortOrder.Ascending)
            where T : IComparable<T>
        {
            var algorithm = SortAlgotithmFactory.Get<T>(sortAlgorithm);
            return algorithm.Sort(enumerable, sortOrder);
        }

        /// <summary>
        /// Sorts an enumeration using various sort algorithms in parallel, and returns the ordered 
        /// enumeration from the first completed sort.
        /// </summary>
        /// <param name="array">Array to sort.</param>
        /// <param name="sortOrder">Sort order.</param>
        /// <param name="sortAlgorithms">Desired sort algorithms to use.</param>
        /// <typeparam name="T">Type of items in array.</typeparam>
        /// <returns></returns>
        public static async Task FastSortUsingAsync<T>(this T[] array, ESortOrder sortOrder, params ESortAlgorithm[] sortAlgorithms)
            where T : IComparable<T>
        {
            if (sortAlgorithms.Length == 0)
                return;

            List<ISortAlgorithm<T>> algorithms = GetSortAlgorithmsList<T>(sortAlgorithms);
            List<Task<T[]>> taskList = GetTaskListForArraySorting(array, sortOrder, algorithms);
            var resultingArray = await SortArrayAsync(array, taskList);
            resultingArray.CopyTo(array, 0);
        }

        /// <summary>
        /// Sorts an enumeration using various sort algorithms in parallel, and returns the ordered 
        /// enumeration from the first completed sort.
        /// </summary>
        /// <param name="enumerable">Array to sort.</param>
        /// <param name="sortOrder">Sort order.</param>
        /// <param name="sortAlgorithms">Desired sort algorithms to use.</param>
        /// <typeparam name="T">Type of items in array.</typeparam>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> FastSortUsingAsync<T>(this IEnumerable<T> enumerable, ESortOrder sortOrder, params ESortAlgorithm[] sortAlgorithms)
            where T : IComparable<T>
        {
            if (sortAlgorithms.Length == 0)
                return enumerable;

            List<ISortAlgorithm<T>> algorithms = GetSortAlgorithmsList<T>(sortAlgorithms);
            List<Task<T[]>> taskList = GetTaskListForEnumerableSorting(enumerable, sortOrder, algorithms);
            return await SortEnumerableAsync(enumerable, taskList);
        }

        private static List<ISortAlgorithm<T>> GetSortAlgorithmsList<T>(ESortAlgorithm[] sortAlgorithms) where T : IComparable<T>
        {
            var algorithms = new List<ISortAlgorithm<T>>();

            foreach (var sortAlgorithm in sortAlgorithms.Distinct())
            {
                var algorithmInstance = SortAlgotithmFactory.Get<T>(sortAlgorithm);
                algorithms.Add(algorithmInstance);
            }

            return algorithms;
        }

        private static List<Task<T[]>> GetTaskListForArraySorting<T>(T[] array, ESortOrder sortOrder, List<ISortAlgorithm<T>> algorithms) where T : IComparable<T>
        {
            var taskList = new List<Task<T[]>>();
            foreach (var algorithm in algorithms)
            {
                var task = Task<T[]>.Run(() =>
                {
                    T[] copiedArray = new T[array.Length];
                    array.CopyTo(copiedArray, 0);

                    return algorithm.Sort(copiedArray, sortOrder);
                });

                taskList.Add(task);
            }

            return taskList;
        }

        private static List<Task<T[]>> GetTaskListForEnumerableSorting<T>(IEnumerable<T> enumerable, ESortOrder sortOrder, List<ISortAlgorithm<T>> algorithms) where T : IComparable<T>
        {
            var taskList = new List<Task<T[]>>();
            foreach (var algorithm in algorithms)
            {
                var task = Task<T[]>.Run(() =>
                {
                    T[] copiedArray = enumerable.ToArray();
                    return algorithm.Sort(copiedArray, sortOrder);
                });

                taskList.Add(task);
            }

            return taskList;
        }

        private static async Task<T[]> SortArrayAsync<T>(T[] array, List<Task<T[]>> taskList) where T : IComparable<T>
        {
            Task<T[]> completedTask = await Task.WhenAny(taskList);
            return await completedTask;
        }


        private static async Task<IEnumerable<T>> SortEnumerableAsync<T>(IEnumerable<T> enumerable, List<Task<T[]>> taskList) where T : IComparable<T>
        {
            Task<T[]> completedTask = await Task.WhenAny(taskList);
            return await completedTask;
        }
    }
}