using NUnit.Framework;
using System;

namespace LibraryList.Test
{
   public abstract class BaseTest
    {
        public abstract void Init(int[] actualArray, int[] expectedArray);
        public abstract void Init(int[] actualArray);

        protected IList _actual;
        
        protected IList _expected;

        [Test]
        public void ToString_WhenMethodUsed_ThenReturnStringList()
        {
            Init(new int[] {1,2,3,4,5,6 });
            Assert.AreEqual("1 2 3 4 5 6", _actual.ToString());
        }

        [TestCase(new int[] {1 },-1)]
        [TestCase(new int[] {1,2 },6)]
        public void IndexerSet_WhenIncorrectIndexPassed_ThenReturnIndexOutOfRangeException(int[] actualArray, int value)
        {
                    Init(actualArray);

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                 _actual[value] = 11;
            });
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { }, new int[] { })]
        public void ToArray_WhenMethodUsed_ThenReturnArray(int[] actualArray, int[] expectedArray)
        {
            Init(actualArray);

            Assert.AreEqual(expectedArray, _actual.ToArray());
        }

        [TestCase(new int[] { 1 }, -1)]
        [TestCase(new int[] { 1, 2 }, 6)]
        public void IndexerGet_WhenIncorrectIndexPassed_ThenReturnIndexOutOfRangeException(int[] actualArray, int index)
        {
            Init(actualArray);

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
              int value = _actual[index];
            });
        }

        [TestCase(new int[] { 1 }, 0, 1)]
        [TestCase(new int[] { 1, 2 }, 1, 2)]
        public void IndexerGet_WhenIncorrectIndexPassed_ThenGetValue(int[] actualArray, int index, int expected)
        {
            Init(actualArray);


            int actual = _actual[index];

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1 }, -1, -1)]
        [TestCase(new int[] { 1, 2 }, 6, 6)]
        public void IndexerSet_WhenIndexPassed_ThenSetValue(int[] actualArray, int value , int expected)
        {
            Init(actualArray);

            _actual[0] = value;

            Assert.AreEqual(expected, _actual[0]);
        }

        [TestCase(new int[] { 1, 2, 3 }, 4, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1 }, 4, new int[] { 1, 4 })]
        [TestCase(new int[] { }, 4, new int[] { 4 })]
        public void AddLast_WhenValuePassed_ThenAddLast(int[] actualArray, int value, int[] expectedArray)
        {
            Init(actualArray, expectedArray);
            _actual.AddLast(value);

            Assert.AreEqual(_expected, _actual);
        }

        [TestCase(new int[] { 1 }, new int[] { 4, 5, 6 }, new int[] { 1, 4, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { }, new int[] { }, new int[] { })]
        public void AddLast_WhenListPassed_ThenAddListInLast(int[] actualArray, int[] arrayForList, int[] expectedArray)
        {
            Init(actualArray, expectedArray);

            _actual.AddLast(DoubleLinkedList.Create(arrayForList));


            Assert.AreEqual(_expected, _actual);
        }

        [TestCase(new int[] { })]
        public void AddLast_WhenNullPassed_ThenReturnArgumentException(int[] actualArray)
        {
            Init(actualArray);

            Assert.Throws<ArgumentNullException>(() =>
            {
                _actual.AddLast(null);
            });
        }

        [TestCase(new int[] { 1, 2, 3 }, 0, new int[] { 0, 1, 2, 3 })]
        [TestCase(new int[] { }, 0, new int[] { 0 })]
        [TestCase(new int[] { 1 }, 0, new int[] { 0, 1 })]
        public void AddFirst_WhenValuePassed_ThenAddFirst(int[] actualArray, int value, int[] expectedArray)
        {
            Init(actualArray, expectedArray);
            _actual.AddFirst(value);

            Assert.AreEqual(_expected, _actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 4, 5, 6, 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 4 }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1 }, new int[] { 0 }, new int[] { 0, 1 })]
        public void AddFirst_WhenListPassed_ThenAddListInFirst(int[] actualArray, int[] arrayForList, int[] expectedArray)
        {
            Init(actualArray, expectedArray);
          
            _actual.AddFirst(DoubleLinkedList.Create(arrayForList));

            Assert.AreEqual(_expected, _actual);
        }

        [TestCase(new int[] { })]
        public void AddFirst_WhenNullPassed_ThenReturnArgumentException(int[] actualArray)
        {
            Init(actualArray);
            Assert.Throws<ArgumentNullException>(() =>
            {
                _actual.AddFirst(null);
            });
        }

        [TestCase(new int[] { }, 0, 10, new int[] { 10 })]
        [TestCase(new int[] { 1 }, 0, 10, new int[] { 10, 1 })]
        [TestCase(new int[] { 1, 2 }, 1, 10, new int[] { 1, 10, 2 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 5, 10, new int[] { 1, 2, 3, 4, 5, 10, 6 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 1, 10, new int[] { 1, 10, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 0, 10, new int[] { 10, 1, 2, 3, 4, 5, 6 })]
        public void AddByIndex_WhenValueAndIndexPassed_ThenAddByIndex(int[] actualArray, int index, int value, int[] expectedArray)
        {
            Init(actualArray,expectedArray);
            _actual.AddByIndex(index, value);

            Assert.AreEqual(_expected, _actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, -1)]
        [TestCase(new int[] { 1, 2, 3 }, 3)]
        public void AddByIndex_WhenIncorrectIndexPassed_ThenReturnIndexOutOfRange(int[] actualArray, int index)
        {
            Init(actualArray);
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                _actual.AddByIndex(index, 0);

            });
        }

        [TestCase(new int[] { }, 0, new int[] { }, new int[] { })]
        [TestCase(new int[] { 2 }, 0, new int[] { 1 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 3 }, 1, new int[] { 2 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 2, new int[] { 4, 5, 6 }, new int[] { 1, 2, 4, 5, 6, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 0, new int[] { 4, 5, 6 }, new int[] { 4, 5, 6, 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 1, new int[] { 4, 5, 6 }, new int[] { 1, 4, 5, 6, 2, 3 })]
        [TestCase(new int[] { }, 0, new int[] { 4, 5, 6 }, new int[] { 4, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3 }, 0, new int[] { }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 2, new int[] { }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { }, 0, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        public void AddByIndex_WhenValidDataPassed_ThenAddByIndex(int[] actualArray, int index, int[] arrayForList, int[] expectedArray)
        {
            Init(actualArray, expectedArray);

           _actual.AddByIndex(index, DoubleLinkedList.Create(arrayForList));

            Assert.AreEqual(_expected, _actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, -1, new int[] { 4, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3 }, 3, new int[] { 4, 5, 6 })]
        public void AddByIndex_WhenIncorrectIndexPassed_ThenReturnIndexOutOfRangeException(int[] actualArray, int index, int[] arrayForList)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                _actual.AddByIndex(index, DoubleLinkedList.Create(arrayForList));
            });
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1 }, new int[] { })]
        public void RemoveLast_WhenMethodCalled_ThenRemoveLast(int[] actualArray, int[] expectedArray)
        {
            Init(actualArray, expectedArray);
            _actual.RemoveLast();

            Assert.AreEqual(_expected, _actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        [TestCase(new int[] { }, new int[] { })]
        public void RemoveFirst_WhenMethodCalled_ThenRemoveFirst(int[] actualArray, int[] expectedArray)
        {
            Init(actualArray, expectedArray);
            _actual.RemoveFirst();

            Assert.AreEqual(_expected, _actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 0, new int[] { 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 2, new int[] { 1, 2, 4 })]
        [TestCase(new int[] { 1, 2, 3 }, 2, new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2 }, 1, new int[] { 1 })]
        [TestCase(new int[] { 1 }, 0, new int[] { })]
        [TestCase(new int[] { }, 0, new int[] { })]
        public void RemoveByIndex_WhenIndexPassed_ThenRemoveByIndex(int[] actualArray, int index, int[] expectedArray)
        {
            Init(actualArray, expectedArray); _actual.RemoveByIndex(index);

            Assert.AreEqual(_expected, _actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, -1)]
        [TestCase(new int[] { 1, 2, 3 }, 3)]
        public void RemoveByIndex_WhenIncorrectIndexPassed_ThenReturnIndexOutOfRangeException(int[] actualArray, int index)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                Init(actualArray);
                _actual.RemoveByIndex(index);
            });
        }

        [TestCase(new int[] { 1, 2, 3 }, 4, new int[] { })]
        [TestCase(new int[] { 1, 2, 3 }, 3, new int[] { })]
        [TestCase(new int[] { 1, 2, 3 }, 2, new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 }, 1, new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2, 3 }, 0, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { }, 0, new int[] { })]
        public void RemoveLast_WhenCountPassed_ThenRemoveLast(int[] actualArray, int count, int[] expectedArray)
        {
            Init(actualArray, expectedArray);

            _actual.RemoveLast(count);

            Assert.AreEqual(_expected, _actual);
        }

        [TestCase(new int[] { }, -1)]
        public void RemoveLast_WhennListIsEmptyAndElementsPassed_ThenArgumentException(int[] actualArray, int count)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Init(actualArray);
                _actual.RemoveLast(count);

            });
        }

        [TestCase(new int[] { 1, 2, 3 }, 3, new int[] { })]
        [TestCase(new int[] { 1, 2, 3 }, 2, new int[] { 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 1, new int[] { 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 0, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 4, new int[] { })]
        [TestCase(new int[] { }, 0, new int[] { })]
        public void RemoveFirst_WheCountPassed_ThenRemoveFirst(int[] actualArray, int count, int[] expectedArray)
        {
            Init(actualArray, expectedArray);
            _actual.RemoveFirst(count);

            Assert.AreEqual(_expected, _actual);
        }

        [TestCase(new int[] { }, -1)]
        public void RemoveFirst_WhennListIsEmptyElementsPassed_ThenArgumentException(int[] actualArray, int count)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Init(actualArray);
                _actual.RemoveFirst(count);

            });
        }

        [TestCase(new int[] { 1, 2, 3 }, 0, 3, new int[] { })]
        [TestCase(new int[] { 1, 2, 3 }, 0, 1, new int[] { 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 0, 0, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 2, 0, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 2, 1, new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2, 3 }, 2, 2, new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2, 3 }, 1, 1, new int[] { 1, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 1, 2, new int[] { 1 })]
        [TestCase(new int[] { 1, 2 }, 1, 1, new int[] { 1 })]
        [TestCase(new int[] { 1 }, 0, 1, new int[] { })]
        public void RemoveByIndex_WhenValidDataPassed_ThenRemoveByIndex(int[] actualArray, int index, int count, int[] expectedArray)
        {
            Init(actualArray, expectedArray);
            _actual.RemoveByIndex(index, count);
            Assert.AreEqual(_expected, _actual);
        }


        [TestCase(new int[] { 1, 2, 3 }, 0, -1)]
        public void RemoveByIndex_WhenIndexOrcountIncorrectPassed_ThenReturnArgumentException(int[] actualArray, int index, int count)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Init(actualArray);
                _actual.RemoveByIndex(index, count);
            });
        }


        [TestCase(new int[] { 1, 2, 3 }, -1, 0)]
        [TestCase(new int[] { 1, 2, 3 }, 6, 0)]
        public void RemoveByIndex_WhenIndexOrcountIncorrectPassed_ThenReturnIndexOutOfRangeException(int[] actualArray, int index, int count)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                Init(actualArray);
                _actual.RemoveByIndex(index, count);
            });
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, new int[] { 8, 7, 6, 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 8, 8, 8, 8, 8, 8, 8, 8, 9, 9, 9, 9, 9, 9, 9 }, new int[] { 9, 9, 9, 9, 9, 9, 9, 8, 8, 8, 8, 8, 8, 8, 8, 8, 7, 6, 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 7, 6, 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 1, 2 }, new int[] { 2, 1 })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        [TestCase(new int[] { }, new int[] { })]
        public void Reverse_WhenMethodCalled_ThenReverseList(int[] actualArray, int[] expectedArray)
        {
            Init(actualArray, expectedArray);
            _actual.Reverse();

            Assert.AreEqual(_expected, _actual);
        }

        [Test]
        public void Reverse_WhenMethodCalled_ThenNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                DoubleLinkedList actual = null;

                actual.Reverse();
            });
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 7)]
        [TestCase(new int[] { 8, 2, 3, 4, 5, 6, 7 }, 0)]
        [TestCase(new int[] { 1, 2, 2 }, 1)]
        [TestCase(new int[] { 1 }, 0)]
        public void FindMaxIndex_WhenMethodCalled_ThenReturnMaxIndex(int[] actualArray, int expected)
        {
            Init(actualArray);

            int actual = _actual.FindMaxIndex();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        [TestCase(null)]
        public void FindMaxIndex_WhenNullOrListIsEmptyPassed_ThenReturnArgumentException(int[] actualArray)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Init(actualArray);

                int actual = _actual.FindMaxIndex();
            });
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 0)]
        [TestCase(new int[] { 8, 2, 3, 4, 5, 6, 1 }, 6)]
        [TestCase(new int[] { 2, 2, 2 }, 0)]
        [TestCase(new int[] { 1 }, 0)]
        [TestCase(new int[] { 6, 5, 4, 3, 4, 5, 6 }, 3)]
        public void FindMinIndex_WhenMethodCalled_ThenReturnMinIndex(int[] actualArray, int expected)
        {
            Init(actualArray);

            int actual = _actual.FindMinIndex();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        [TestCase(null)]
        public void FindMinIndex_WhenNullOrListIsEmptyPassed_ThenReturnArgumentException(int[] actualArray)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Init(actualArray);

                int actual = _actual.FindMaxIndex();
            });
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 8)]
        [TestCase(new int[] { 8, 2, 3, 4, 5, 6, 7 }, 8)]
        [TestCase(new int[] { 1, 2, 2 }, 2)]
        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { 2, 3, 4, 6, 4, 5, 6 }, 6)]
        public void FindMaxElement_WhenMethodCalled_ThenReturnMaxElement(int[] actualArray, int expected)
        {
            Init(actualArray);

            int actual = _actual.FindMaxElement();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        [TestCase(null)]
        public void FindMaxElement_WhenNoElementsInCollection_ThenReturnArgumentException(int[] actualArray)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Init(actualArray);

                int actual = _actual.FindMaxElement();
            });
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 1)]
        [TestCase(new int[] { 8, 2, 3, 4, 5, 6, 1 }, 1)]
        [TestCase(new int[] { 2, 2, 2 }, 2)]
        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { 6, 5, 4, 3, 4, 5, 6 }, 3)]
        public void FindMinElement_WhenMethodCalled_ThenReturnMinElement(int[] actualArray, int expected)
        {
            Init(actualArray);

            int actual = _actual.FindMinElement();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        [TestCase(null)]
        public void FindMinElement_WhenNoElementsInCollection_ThenReturnArgumentException(int[] actualArray)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Init(actualArray);

                int actual = _actual.FindMinElement();
            });
        }

        [TestCase(new int[] { 7, 3, 2, 5, 1, 6, 2 }, new int[] { 1, 2, 2, 3, 5, 6, 7 })]
        [TestCase(new int[] { 2, 2, 2, 2, 2, 2, 2 }, new int[] { 2, 2, 2, 2, 2, 2, 2 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 3, 2, 1 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 3, 1, 1 }, new int[] { 1, 1, 3 })]
        [TestCase(new int[] { 3, 3, 1 }, new int[] { 1, 3, 3 })]
        [TestCase(new int[] { 3, 1 }, new int[] { 1, 3 })]
        [TestCase(new int[] { 2, 2 }, new int[] { 2, 2 })]
        [TestCase(new int[] { }, new int[] { })]
        public void Sort_WhenIsDescendingFalse_ThenSortAscending(int[] actualArray, int[] expectedArray)
        {
            Init(actualArray, expectedArray);

            bool isDescending = true;

            _actual.Sort(isDescending);

            Assert.AreEqual(_expected, _actual);
        }

        [TestCase(new int[] { 7, 3, 2, 5, 1, 6, 2 }, new int[] { 7, 6, 5, 3, 2, 2, 1 })]
        [TestCase(new int[] { 2, 2, 2, 2, 2, 2, 2 }, new int[] { 2, 2, 2, 2, 2, 2, 2 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 3, 2, 1 }, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 1, 1, 3 }, new int[] { 3, 1, 1 })]
        [TestCase(new int[] { 1, 3, 3 }, new int[] { 3, 3, 1 })]
        [TestCase(new int[] { 1, 3 }, new int[] { 3, 1 })]
        [TestCase(new int[] { 2, 2 }, new int[] { 2, 2 })]
        [TestCase(new int[] { }, new int[] { })]
        public void Sort_WhenIsDescendingTrue_ThenSortDescending(int[] actualArray, int[] expectedArray)
        {
            Init(actualArray, expectedArray);
            bool isDescending = false;

            _actual.Sort(isDescending);

            Assert.AreEqual(_expected, _actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 1, new int[] { 2, 3, 4, 5, 6, 7, 8 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 8, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { 1, 1, 3, 4, 5, 6, 8, 8 }, 10, new int[] { 1, 1, 3, 4, 5, 6, 8, 8 })]
        [TestCase(new int[] { 1, 1, 3, 4, 5, 6, 8, 8 }, 8, new int[] { 1, 1, 3, 4, 5, 6, 8 })]
        public void RemoveByValue_WhenValuePassed_ThenRemoveValue(int[] actualArray, int value, int[] expectedArray)
        {
            Init(actualArray, expectedArray);

            _actual.RemoveByValue(value);

            Assert.AreEqual(_expected, _actual);
        }

        [TestCase(new int[] { 1, 2, 1, 4, 1, 6, 7, 8 }, 1, new int[] { 2, 4, 6, 7, 8 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 8, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { 1, 1, 3, 4, 5, 6, 8, 8 }, 10, new int[] { 1, 1, 3, 4, 5, 6, 8, 8 })]
        [TestCase(new int[] { 8, 8, 8 }, 8, new int[] { })]
        public void RemoveAllByValue_WhenValue_TnenRemoveAllValue(int[] actualArray, int value, int[] expectedArray)
        {
            Init(actualArray, expectedArray);

            _actual.RemoveAllByValue(value);

            Assert.AreEqual(_expected, _actual); ;
        }


    }
}
