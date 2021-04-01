using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryList.Test
{
    class DoubleLinkedTest : BaseTest
    {
        public override void Init(int[] actualArray, int[] expectedArray)
        {
            _actual = DoubleLinkedList.Create(actualArray);
            _expected = DoubleLinkedList.Create(expectedArray);
        }

        public override void Init(int[] actualArray)
        {
            _actual = DoubleLinkedList.Create(actualArray);
        }
    }
}
