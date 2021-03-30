using NUnit.Framework;
using System;

namespace LibraryList.Test
{
    public class ArrayListTests
    {
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1 }, new int[] { 1, 4 })]
        [TestCase(new int[] { }, new int[] { 4 })]
        public void AddLast_WhenValuePassed_ThenAddLast(int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
           
          
            actual.AddLast(4);

            Assert.AreEqual(new ArrayList(expectedArray), actual);
        }

        [TestCase(new int[] { 1 }, new int[] { 4, 5, 6 }, new int[] { 1, 4, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { }, new int[] { 1, 2, 3 })]
        public void AddLast_WhenListPassed_ThenAddListInLast(int[] actualArray, int[] arrayForList, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList list = new ArrayList(arrayForList);

            actual.AddLast(list);

            Assert.AreEqual(new ArrayList(expectedArray), actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 0, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [TestCase(new int[] { }, 0, new int[] { 0 })]
        public void AddFirst_WhenValuePassed_ThenAddFirst(int[] actualArray, int value, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);

            actual.AddFirst(value);

            Assert.AreEqual(new ArrayList(expectedArray), actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 4, 5, 6, 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        public void AddFirst_WhenListPassed_ThenAddListInFirst(int[] actualArray, int[] arrayForList, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList list = new ArrayList(arrayForList);

            actual.AddFirst(list);

            Assert.AreEqual(new ArrayList(expectedArray), actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 0, -2, new int[] { -2, 1, 2, 3 })]
        [TestCase(new int[] { }, 0, 10, new int[] { 10 })]
        [TestCase(new int[] { 3, 3, 3, 3, 3, 3 }, 5, 10, new int[] { 3, 3, 3, 3, 3, 10, 3 })]
        [TestCase(new int[] { 3, 3, 3, 3, 3, 3 }, 1, 10, new int[] { 3, 10, 3, 3, 3, 3, 3 })]
        public void AddByIndex_WhenValueAndIndexPassed_ThenAddByIndex(int[] actualArray, int index, int value, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);

            actual.AddByIndex(index, value);

            Assert.AreEqual(new ArrayList(expectedArray), actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, -1, -2, new int[] { -2, 1, 2, 3 })]
        [TestCase(new int[] { 3, 3, 3, 3, 3, 3 }, 6, 4, new int[] { 3, 3, 3, 3, 3, 4, 3 })]
        public void AddByIndex_WhenValueAndIndexPassed_ThenReturnIndexOutOfRangeException(int[] actualArray, int index, int value, int[] expectedArray)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                ArrayList actual = new ArrayList(actualArray);
                ArrayList expected = new ArrayList(expectedArray);

                actual.AddByIndex(index, value);
            });
        }

        [TestCase(new int[] { 1, 2, 3 }, 2, new int[] { 4, 5, 6 }, new int[] { 1, 2, 4, 5, 6, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 0, new int[] { 4, 5, 6 }, new int[] { 4, 5, 6, 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 1, new int[] { 4, 5, 6 }, new int[] { 1, 4, 5, 6, 2, 3 })]
        [TestCase(new int[] { }, 0, new int[] { 4, 5, 6 }, new int[] { 4, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3 }, 0, new int[] { }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 2, new int[] { }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { }, 0, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        public void AddByIndex_WhenListAndIndexPassed_ThenAddListByIndex(int[] actualArray, int index, int[] arrayForList, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList list = new ArrayList(arrayForList);

            actual.AddByIndex(index, list);

            Assert.AreEqual(new ArrayList(expectedArray), actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, -1, new int[] { 4, 5, 6 }, new int[] { 1, 2, 4, 5, 6, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 3, new int[] { 4, 5, 6 }, new int[] { 1, 4, 5, 6, 2, 3 })]
        public void AddByIndex_WhenListAndIndexPassed_ThenReturnIndexOutOfRangeException(int[] actualArray, int index, int[] arrayForList, int[] expectedArray)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                ArrayList actual = new ArrayList(actualArray);
                ArrayList list = new ArrayList(arrayForList);

                actual.AddByIndex(index, list);

                Assert.AreEqual(new ArrayList(expectedArray), actual);
            });
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2 })]
        [TestCase(new int[] { }, new int[] { })]
        public void RemoveLast_WhenMethodCalled_ThenRemoveLast(int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);

            actual.RemoveLast();

            Assert.AreEqual(new ArrayList(expectedArray), actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        [TestCase(new int[] { }, new int[] { })]
        public void RemoveFirst_WhenMethodCalled_ThenRemoveFirst(int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);

            actual.RemoveFirst();

            Assert.AreEqual(new ArrayList(expectedArray), actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 0, new int[] { 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 2, new int[] { 1, 2 })]
        [TestCase(new int[] { }, 0, new int[] { })]
        public void RemoveByIndex_WhenIndexPassed_ThenRemoveByIndex(int[] actualArray, int index, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);

            actual.RemoveByIndex(index);

            Assert.AreEqual(new ArrayList(expectedArray), actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, -1)]
        [TestCase(new int[] { 3, 3, 3, 3, 3, 3 }, 6)]
        public void RemoveByIndex_WhenIndexPassed_ThenReturnIndexOutOfRangeException(int[] actualArray, int index)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                ArrayList actual = new ArrayList(actualArray);

                actual.RemoveByIndex(index);
            });
        }

        [TestCase(new int[] { 1, 2, 3 }, 0, 3, new int[] { })]
        [TestCase(new int[] { 1, 2, 3 }, 0, 4, new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 4, new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 8, 0, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 7, 1, new int[] { 1, 2, 3, 4, 5, 6, 7, 9 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 7, 2, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 8, 10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        public void RemoveByIndex_WhenIndexAndNElements_ThenRemoveByIndexNElements(int[] actualArray, int index, int nElements, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);

            actual.RemoveByIndex(index, nElements);

            Assert.AreEqual(new ArrayList(expectedArray), actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, -1, 0)]
        [TestCase(new int[] { 3, 3, 3, 3, 3, 3 }, 6, 2)]
        public void RemoveByIndex_WhenIndexAndNElements_ThenReturnIndexOutOfRangeException(int[] actualArray, int index, int nElements)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                ArrayList actual = new ArrayList(actualArray);

                actual.RemoveByIndex(index, nElements);
            });
        }

        [TestCase(new int[] { 1, 2, 3 }, -1)]
        [TestCase(new int[] { 3, 3, 3, 3, 3, 3 }, 6)]
        public void Indexsator_WhenIndexPassed_ThenReturnIndexOutOfRangeException(int[] actualArray, int index)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                ArrayList actual = new ArrayList(actualArray);

                actual[index] = 1;
            });
        }

        [TestCase(new int[] { 1, 2, 3 }, 0, -1)]
        public void RemoveByIndex_WhenIndexAndNElements_ThenReturnArgumentException(int[] actualArray, int index, int nElements)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ArrayList actual = new ArrayList(actualArray);

                actual.RemoveByIndex(index, nElements);
            });
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 2, 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 10, -1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 1, 0)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 8, 7)]
        public void GetIndexByValue_WhenValuePassed_ThenReturnIndex(int[] actualArray, int value, int expected)
        {
            ArrayList list = new ArrayList(actualArray);
            int actual = list.GetIndexByValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, new int[] { 8, 7, 6, 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 7, 6, 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { }, new int[] { })]
        public void Reverse_WhenMethodCalled_ThenReverseList(int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);

            actual.Reverse();

            Assert.AreEqual(new ArrayList(expectedArray), actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 7)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 7)]
        public void FindMaxIndex_WhenMethodCalled_ThenReturnMaxIndex(int[] actualArray, int expected)
        {
            ArrayList list = new ArrayList(actualArray);
            int actual = list.FindMaxIndex();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, 6)]
        public void FindMaxIndex_WhenMethodCalled_ThenReturnArgumentException(int[] actualArray, int expected)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ArrayList list = new ArrayList(actualArray);
                int actual = list.FindMaxIndex();
            });
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 0)]
        [TestCase(new int[] { 1, 1, 3, 4, 5, 6, 7, 8 }, 0)]
        public void FindMinIndex_WhenMethodCalled_ThenReturnMinIndex(int[] actualArray, int expected)
        {
            ArrayList list = new ArrayList(actualArray);
            int actual = list.FindMinIndex();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, 6)]
        public void FindMinIndex_WhenMethodCalled_ThenReturnArgumentException(int[] actualArray, int expected)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ArrayList list = new ArrayList(actualArray);
                int actual = list.FindMaxIndex();
            });
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 8)]
        [TestCase(new int[] { 1, 1, 3, 4, 5, 6, 8, 8 }, 8)]
        public void FindMaxElement_WhenMethodCalled_ThenReturnMaxElement(int[] actualArray, int expected)
        {
            ArrayList list = new ArrayList(actualArray);
            int actual = list.FindMaxElement();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 1)]
        [TestCase(new int[] { 1, 1, 3, 4, 5, 6, 8, 8 }, 1)]
        public void FindMinElement_WhenMethodCalled_ThenReturnMinElement(int[] actualArray, int expected)
        {
            ArrayList list = new ArrayList(actualArray);
            int actual = list.FindMinElement();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 1, new int[] { 2, 3, 4, 5, 6, 7, 8 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 8, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { 1, 1, 3, 4, 5, 6, 8, 8 }, 10, new int[] { 1, 1, 3, 4, 5, 6, 8, 8 })]
        [TestCase(new int[] { 1, 1, 3, 4, 5, 6, 8, 8 }, 8, new int[] { 1, 1, 3, 4, 5, 6, 8 })]
        public void RemoveByValue_WhenValuePassed_ThenRemoveValue(int[] actualArray, int value, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);

            actual.RemoveByValue(value);

            Assert.AreEqual(new ArrayList(expectedArray), actual);
        }

        [TestCase(new int[] { 1, 2, 1, 4, 1, 6, 7, 8 }, 1, new int[] { 2, 4, 6, 7, 8 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 8, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { 1, 1, 3, 4, 5, 6, 8, 8 }, 10, new int[] { 1, 1, 3, 4, 5, 6, 8, 8 })]
        [TestCase(new int[] { 8, 8, 8 }, 8, new int[] { })]
        public void RemoveAllByValue_WhenValue_TnenRemoveAllValue(int[] actualArray, int value, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);

            actual.RemoveAllByValue(value);

            Assert.AreEqual(new ArrayList(expectedArray), actual);
        }

        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1, 2, 1, 4, 1, 6, 7, 8 }, new int[] { 1, 1, 1, 2, 4, 6, 7, 8 })]
        public void SortAscendingInsert_WhenMethodCalled_ThenSortAscendingInsert(int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);

            actual.Sort(true);

            Assert.AreEqual(new ArrayList(expectedArray), actual);
        }

        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1, 2, 1, 4, 1, 6, 7, 8 }, new int[] { 8, 7, 6, 4, 2, 1, 1, 1 })]
        public void SortDescendingInsert_WhenMethodCalled_ThenSortDescendingInsert(int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);

            actual.Sort(false);

            Assert.AreEqual(new ArrayList(expectedArray), actual);
        }
    }

}
