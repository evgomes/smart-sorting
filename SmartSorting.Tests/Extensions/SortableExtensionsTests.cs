using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartSorting.Extensions;
using SmartSorting.Structure;

namespace SmartSorting.Tests.Extensions
{
    [TestClass]
    public class SortableExtensionsTests
    {
        [TestMethod]
        public void Should_Sort_Array_With_Specified_Algorithm_In_Ascending_Order()
        {
            int[] array = { 1, 5, 3, 2, 4 };
            array.SortUsing(ESortAlgorithm.BubbleSort, ESortOrder.Ascending);

            Assert.IsTrue(array[0] == 1);
            Assert.IsTrue(array[1] == 2);
            Assert.IsTrue(array[2] == 3);
            Assert.IsTrue(array[3] == 4);
            Assert.IsTrue(array[4] == 5);
        }

        [TestMethod]
        public void Should_Sort_Array_With_Specified_Algorithm_In_Descending_Order()
        {
            int[] array = { 1, 5, 3, 2, 4 };
            array.SortUsing(ESortAlgorithm.BubbleSort, ESortOrder.Descending);

            Assert.IsTrue(array[0] == 5);
            Assert.IsTrue(array[1] == 4);
            Assert.IsTrue(array[2] == 3);
            Assert.IsTrue(array[3] == 2);
            Assert.IsTrue(array[4] == 1);
        }

        [TestMethod]
        public async Task Should_Sort_Array_With_Fastest_Algorithm_Available()
        {
            int[] array = { 1, 5, 3, 2, 4 };
            await array.FastSortUsingAsync(ESortOrder.Ascending, ESortAlgorithm.BubbleSort, ESortAlgorithm.InsertionSort);

            Assert.IsTrue(array[0] == 1);
            Assert.IsTrue(array[1] == 2);
            Assert.IsTrue(array[2] == 3);
            Assert.IsTrue(array[3] == 4);
            Assert.IsTrue(array[4] == 5);
        }

        [TestMethod]
        public void Should_Sort_Enumerable_With_Specified_Algorithm_In_Ascending_Order()
        {
            var enumeration = new List<TodoItem>
            {
                new TodoItem(1),
                new TodoItem(5),
                new TodoItem(3),
                new TodoItem(2),
                new TodoItem(4),
            };

            enumeration = enumeration.SortUsing(ESortAlgorithm.BubbleSort, ESortOrder.Ascending).ToList();

            Assert.IsTrue(enumeration[0].Id == 1);
            Assert.IsTrue(enumeration[1].Id == 2);
            Assert.IsTrue(enumeration[2].Id == 3);
            Assert.IsTrue(enumeration[3].Id == 4);
            Assert.IsTrue(enumeration[4].Id == 5);
        }

        [TestMethod]
        public void Should_Sort_Enumerable_With_Specified_Algorithm_In_Descending_Order()
        {
            var enumeration = new List<TodoItem>
            {
                new TodoItem(1),
                new TodoItem(5),
                new TodoItem(3),
                new TodoItem(2),
                new TodoItem(4),
            };

            enumeration = enumeration.SortUsing(ESortAlgorithm.BubbleSort, ESortOrder.Descending).ToList();

            Assert.IsTrue(enumeration[0].Id == 5);
            Assert.IsTrue(enumeration[1].Id == 4);
            Assert.IsTrue(enumeration[2].Id == 3);
            Assert.IsTrue(enumeration[3].Id == 2);
            Assert.IsTrue(enumeration[4].Id == 1);
        }

        [TestMethod]
        public async Task Should_Sort_Enumerable_With_Fastest_Algorithm_Available()
        {
            var enumeration = new List<TodoItem>
            {
                new TodoItem(1),
                new TodoItem(5),
                new TodoItem(3),
                new TodoItem(2),
                new TodoItem(4),
            };

            var resultingEnumeration = await enumeration.FastSortUsingAsync(ESortOrder.Ascending, ESortAlgorithm.BubbleSort, ESortAlgorithm.InsertionSort);
            enumeration = resultingEnumeration.ToList();

            Assert.IsTrue(enumeration[0].Id == 1);
            Assert.IsTrue(enumeration[1].Id == 2);
            Assert.IsTrue(enumeration[2].Id == 3);
            Assert.IsTrue(enumeration[3].Id == 4);
            Assert.IsTrue(enumeration[4].Id == 5);
        }
    }
}