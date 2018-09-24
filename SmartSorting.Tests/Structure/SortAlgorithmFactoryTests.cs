using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartSorting.Algorithms;
using SmartSorting.Structure;

namespace SmartSorting.Tests.Structure
{
    [TestClass]
    public class SortAlgorithmFactoryTests
    {
        [TestMethod]
        public void Should_Instance_BubbleSort()
        {
            var algorithm = SortAlgotithmFactory.Get<int>(ESortAlgorithm.BubbleSort);
            Assert.IsTrue(algorithm.GetType() == typeof(BubbleSort<int>));
        }


        [TestMethod]
        public void Should_Instance_InsertionSort()
        {
            var algorithm = SortAlgotithmFactory.Get<int>(ESortAlgorithm.InsertionSort);
            Assert.IsTrue(algorithm.GetType() == typeof(InsertionSort<int>));
        }

        [TestMethod]
        public void Should_Instance_SelectionSort()
        {
            var algorithm = SortAlgotithmFactory.Get<int>(ESortAlgorithm.SelectionSort);
            Assert.IsTrue(algorithm.GetType() == typeof(SelectionSort<int>));
        }

        [TestMethod]
        public void Should_Instance_QuickSort()
        {
            var algorithm = SortAlgotithmFactory.Get<int>(ESortAlgorithm.QuickSort);
            Assert.IsTrue(algorithm.GetType() == typeof(QuickSort<int>));
        }

        [TestMethod]
        public void Should_Instance_HeapSort()
        {
            var algorithm = SortAlgotithmFactory.Get<int>(ESortAlgorithm.HeapSort);
            Assert.IsTrue(algorithm.GetType() == typeof(HeapSort<int>));
        }

        [TestMethod]
        public void Should_Instance_MergeSort()
        {
            var algorithm = SortAlgotithmFactory.Get<int>(ESortAlgorithm.MergeSort);
            Assert.IsTrue(algorithm.GetType() == typeof(MergeSort<int>));
        }
    }
}