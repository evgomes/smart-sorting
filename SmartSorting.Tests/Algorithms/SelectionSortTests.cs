using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartSorting.Algorithms;
using SmartSorting.Structure;
using SmartSorting.Tests.Extensions;

namespace SmartSorting.Tests.Algorithms
{
    [TestClass]
    public class SelectionSortTests
    {
        [TestMethod]
        public void Should_Sort_Int_Array_With_Ascending_Direction()
        {
            var sortAlgorithm = new SelectionSort<int>();
            int[] numbers = { 1, 3, 5, 2, 4 };

            numbers = sortAlgorithm.Sort(numbers, ESortOrder.Ascending);

            Assert.IsTrue(numbers[0] == 1);
            Assert.IsTrue(numbers[1] == 2);
            Assert.IsTrue(numbers[2] == 3);
            Assert.IsTrue(numbers[3] == 4);
            Assert.IsTrue(numbers[4] == 5);
        }

        [TestMethod]
        public void Should_Sort_Int_Array_With_Descending_Direction()
        {
            var sortAlgorithm = new SelectionSort<int>();
            int[] numbers = { 1, 3, 5, 2, 4 };

            numbers = sortAlgorithm.Sort(numbers, ESortOrder.Descending);

            Assert.IsTrue(numbers[0] == 5);
            Assert.IsTrue(numbers[1] == 4);
            Assert.IsTrue(numbers[2] == 3);
            Assert.IsTrue(numbers[3] == 2);
            Assert.IsTrue(numbers[4] == 1);
        }

        [TestMethod]
        public void Should_Sort_Float_Array_With_Ascending_Direction()
        {
            var sortAlgorithm = new SelectionSort<float>();
            float[] numbers = { 1.1f, 1.8f, 1.2f, 2.1f, 0 };

            numbers = sortAlgorithm.Sort(numbers, ESortOrder.Ascending);

            Assert.IsTrue(numbers[0] == 0);
            Assert.IsTrue(numbers[1] == 1.1f);
            Assert.IsTrue(numbers[2] == 1.2f);
            Assert.IsTrue(numbers[3] == 1.8f);
            Assert.IsTrue(numbers[4] == 2.1f);
        }

        [TestMethod]
        public void Should_Sort_Float_Array_With_Descending_Direction()
        {
            var sortAlgorithm = new SelectionSort<float>();
            float[] numbers = { 1.1f, 1.8f, 1.2f, 2.1f, 0 };

            numbers = sortAlgorithm.Sort(numbers, ESortOrder.Descending);

            Assert.IsTrue(numbers[0] == 2.1f);
            Assert.IsTrue(numbers[1] == 1.8f);
            Assert.IsTrue(numbers[2] == 1.2f);
            Assert.IsTrue(numbers[3] == 1.1f);
            Assert.IsTrue(numbers[4] == 0);
        }

        [TestMethod]

        public void Should_Sort_Decimal_Array_With_Ascending_Direction()
        {
            var sortAlgorithm = new SelectionSort<decimal>();
            decimal[] numbers = { 1.1M, 1.8M, 1.2M, 2.1M, 0 };

            numbers = sortAlgorithm.Sort(numbers, ESortOrder.Ascending);

            Assert.IsTrue(numbers[0] == 0);
            Assert.IsTrue(numbers[1] == 1.1M);
            Assert.IsTrue(numbers[2] == 1.2M);
            Assert.IsTrue(numbers[3] == 1.8M);
            Assert.IsTrue(numbers[4] == 2.1M);
        }

        [TestMethod]
        public void Should_Sort_Decimal_Array_With_Descending_Direction()
        {
            var sortAlgorithm = new SelectionSort<decimal>();
            decimal[] numbers = { 1.1M, 1.8M, 1.2M, 2.1M, 0 };

            numbers = sortAlgorithm.Sort(numbers, ESortOrder.Descending);

            Assert.IsTrue(numbers[0] == 2.1M);
            Assert.IsTrue(numbers[1] == 1.8M);
            Assert.IsTrue(numbers[2] == 1.2M);
            Assert.IsTrue(numbers[3] == 1.1M);
            Assert.IsTrue(numbers[4] == 0);
        }

        [TestMethod]
        public void Should_Sort_Double_Array_With_Ascending_Direction()
        {
            var sortAlgorithm = new SelectionSort<double>();
            double[] numbers = { 1.1214, 1.8125, 1.1215, 2.101, 1 };

            numbers = sortAlgorithm.Sort(numbers, ESortOrder.Ascending);

            Assert.IsTrue(numbers[0] == 1);
            Assert.IsTrue(numbers[1] == 1.1214);
            Assert.IsTrue(numbers[2] == 1.1215);
            Assert.IsTrue(numbers[3] == 1.8125);
            Assert.IsTrue(numbers[4] == 2.101);
        }

        [TestMethod]
        public void Should_Sort_Double_Array_With_Descending_Direction()
        {
            var sortAlgorithm = new SelectionSort<double>();
            double[] numbers = { 1.1214, 1.8125, 1.1215, 2.101, 1 };

            numbers = sortAlgorithm.Sort(numbers, ESortOrder.Descending);

            Assert.IsTrue(numbers[0] == 2.101);
            Assert.IsTrue(numbers[1] == 1.8125);
            Assert.IsTrue(numbers[2] == 1.1215);
            Assert.IsTrue(numbers[3] == 1.1214);
            Assert.IsTrue(numbers[4] == 1);
        }

        [TestMethod]

        public void Should_Sort_String_Array_With_Ascending_Direction()
        {
            var sortAlgorithm = new SelectionSort<string>();
            string[] strings = { "acb", "abc", "cab", "eeg", "eef" };

            strings = sortAlgorithm.Sort(strings, ESortOrder.Ascending);

            Assert.IsTrue(strings[0] == "abc");
            Assert.IsTrue(strings[1] == "acb");
            Assert.IsTrue(strings[2] == "cab");
            Assert.IsTrue(strings[3] == "eef");
            Assert.IsTrue(strings[4] == "eeg");
        }

        [TestMethod]
        public void Should_Sort_String_Array_With_Descending_Direction()
        {
            var sortAlgorithm = new SelectionSort<string>();
            string[] strings = { "acb", "abc", "cab", "eeg", "eef" };

            strings = sortAlgorithm.Sort(strings, ESortOrder.Descending);

            Assert.IsTrue(strings[0] == "eeg");
            Assert.IsTrue(strings[1] == "eef");
            Assert.IsTrue(strings[2] == "cab");
            Assert.IsTrue(strings[3] == "acb");
            Assert.IsTrue(strings[4] == "abc");
        }

        [TestMethod]
        public void Should_Sort_IEnumerable_With_Ascending_Direction()
        {
            var sortAlgorithm = new SelectionSort<int>();
            IEnumerable<int> enumerable = new List<int> { 1, 3, 5, 2, 4 };

            enumerable = sortAlgorithm.Sort(enumerable, ESortOrder.Ascending);

            Assert.IsTrue(enumerable.ElementAt(0) == 1);
            Assert.IsTrue(enumerable.ElementAt(1) == 2);
            Assert.IsTrue(enumerable.ElementAt(2) == 3);
            Assert.IsTrue(enumerable.ElementAt(3) == 4);
            Assert.IsTrue(enumerable.ElementAt(4) == 5);
        }

        [TestMethod]
        public void Should_Sort_IEnumerable_With_Descending_Direction()
        {
            var sortAlgorithm = new SelectionSort<int>();
            IEnumerable<int> enumerable = new List<int> { 1, 3, 5, 2, 4 };

            enumerable = sortAlgorithm.Sort(enumerable, ESortOrder.Descending);

            Assert.IsTrue(enumerable.ElementAt(0) == 5);
            Assert.IsTrue(enumerable.ElementAt(1) == 4);
            Assert.IsTrue(enumerable.ElementAt(2) == 3);
            Assert.IsTrue(enumerable.ElementAt(3) == 2);
            Assert.IsTrue(enumerable.ElementAt(4) == 1);
        }

        [TestMethod]
        public void Should_Sort_IEnumerable_Of_Custom_Type_Witch_Ascending_Direction()
        {
            var sortAlgorithm = new SelectionSort<TodoItem>();
            var enumeration = new List<TodoItem>
            {
                new TodoItem(1),
                new TodoItem(5),
                new TodoItem(3),
                new TodoItem(2),
                new TodoItem(4),
            };

            enumeration = sortAlgorithm.Sort(enumeration, ESortOrder.Ascending).ToList();

            Assert.IsTrue(enumeration[0].Id == 1);
            Assert.IsTrue(enumeration[1].Id == 2);
            Assert.IsTrue(enumeration[2].Id == 3);
            Assert.IsTrue(enumeration[3].Id == 4);
            Assert.IsTrue(enumeration[4].Id == 5);
        }

        [TestMethod]
        public void Should_Sort_IEnumerable_Of_Custom_Type_Witch_Descending_Direction()
        {
            var sortAlgorithm = new SelectionSort<TodoItem>();
            var enumeration = new List<TodoItem>
            {
                new TodoItem(1),
                new TodoItem(5),
                new TodoItem(3),
                new TodoItem(2),
                new TodoItem(4),
            };

            enumeration = sortAlgorithm.Sort(enumeration, ESortOrder.Descending).ToList();

            Assert.IsTrue(enumeration[0].Id == 5);
            Assert.IsTrue(enumeration[1].Id == 4);
            Assert.IsTrue(enumeration[2].Id == 3);
            Assert.IsTrue(enumeration[3].Id == 2);
            Assert.IsTrue(enumeration[4].Id == 1);
        }
    }
}