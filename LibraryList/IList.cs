
namespace LibraryList
{
    public interface IList
    {
        int Length { get; }

        public int this[int index] { get; set; }

        void AddLast(int value);

        void AddFirst(int value);

        void AddByIndex(int index, int value);
        void AddByIndex(int index, IList obj);

        void RemoveLast();
        void RemoveLast(int nElements);

        void RemoveFirst();
        void RemoveFirst(int nElements);

        void RemoveByIndex(int index);
        void RemoveByIndex(int index, int nElements);

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