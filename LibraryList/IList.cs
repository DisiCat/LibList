using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryList
{
    interface IList
    {
        int Length { get; }

        public int this[int index] { get; set; }

        void AddLast(int value);

        void AddFirst(int value);

        void AddByIndex(int index, int value);

        void RemoveLast();

        void RemoveFirst();

        void RemoveByIndex(int index);

        int GetIndexByValue(int value);

        void Reverse();

        int FindMaxIndex();

        int FindMinIndex();

        int FindMaxElement();

        int FindMinElement();

        void RemoveByValue(int value);

        void RemoveAllByValue(int value);

        void Sort(bool isDescending);
    }
}
