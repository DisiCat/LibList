
namespace LibraryList
{
    public interface IList
    {
        int Length { get; }

        public int this[int index] { get; set; }

        void AddLast(int value);

        void AddLast(IList obj);

        void AddFirst(int value);

        void AddFirst(IList obj);

        void AddByIndex(int index, int value);

        void AddByIndex(int index, IList obj);

        void RemoveLast();

        void RemoveLast(int count);

        void RemoveFirst();

        void RemoveFirst(int count);

        void RemoveByIndex(int index);

        void RemoveByIndex(int index, int count);

        int GetIndexByValue(int value);

        void Reverse();

        int FindMaxIndex();

        int FindMinIndex();

        int FindMaxElement();

        int FindMinElement();

        void RemoveByValue(int value);

        void RemoveAllByValue(int value);

        void Sort(bool isDecending);

        int[] ToArray();

        string ToString();

        bool Equals(object obj);
    }
}

