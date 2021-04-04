using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryList.Test
{
    class ArrayListTest : BaseTest
    {
        public override void Init(int[] actualArray, int[] expectedArray)
        {
            _actual = ArrayList.Create(actualArray);
            _expected = ArrayList.Create(expectedArray);
        }

        public override void Init(int[] actualArray)
        {
            _actual = ArrayList.Create(actualArray);
        }
    }
}
