using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryList.Test
{
    class LinkedListTest : BaseTest
    {
        public override void Init(int[] actualArray, int[] expectedArray)
        {
            _actual = LinkedList.Create(actualArray);
            _expected = LinkedList.Create(expectedArray);
        }

        public override void Init(int[] actualArray)
        {
            _actual = LinkedList.Create(actualArray);
        }
    }
}
