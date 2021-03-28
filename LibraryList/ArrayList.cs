using System;

namespace LibraryList
{
    public class ArrayList
    {
        public int Length { get; private set; }

        private int[] _array;

        private const int indexZero = 0;

        private const int shiftByOne = 1;

        public ArrayList()
        {
            Length = 0;
            _array = new int[10];
        }

        public ArrayList(int el)
        {
            Length = 0;
            _array = new int[10];

            AddFirst(el);
        }

        public ArrayList(int[] initArray)
        {
            if (!(initArray == null))
            {
                Length = 0;
                _array = new int[initArray.Length];

                for (int i = 0; i < initArray.Length; i++)
                {
                    AddLast(initArray[i]);
                }
            }
            else
            {
                throw new ArgumentException("Ti she duurak? kuda null pihaech?");
            }
        }

        public int this[int index]
        {
            get
            {
                return _array[index];
            }

            set
            {
                if (!(index >= Length || index <= 0))
                {
                    _array[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException(" Index out of range");
                }
            }
        }

        public void AddLast(int value)
        {
            Resize(Length);

            _array[Length++] = value;
        }

        public void AddLast(ArrayList list)
        {
            int oldLength = Length;
            Length += list.Length;

            Resize(oldLength);

            for (int i = 0; i < list.Length; ++i)
            {
                _array[oldLength + i] = list[i];
            }
        }

        public void AddFirst(int value)
        {
            AddByIndex(indexZero, value);
        }

        public void AddFirst(ArrayList list)
        {
            AddByIndex(indexZero, list);
        }

        public void AddByIndex(int index, int value)
        {
            if ((index == 0 && Length == 0) || (index < Length && index >= 0))
            {
                Resize(Length);
                Length++;

                ShiftRight(index, shiftByOne);

                _array[index] = value;
            }
            else
            {
                throw new IndexOutOfRangeException("Index Out Of Randge ");
            }
        }

        public void AddByIndex(int index, ArrayList list)
        {
            if ((index == 0 && Length == 0) || (index < Length && index >= 0))
            {
                int oldLength = Length;
                Length += list.Length;

                Resize(oldLength);

                ShiftRight(index + list.Length - 1, list.Length);

                for (int i = 0; i < list.Length; ++i)
                {
                    _array[i + index] = list[i];
                }
            }
            else
            {
                throw new IndexOutOfRangeException("Index Out Of Randge ");
            }
        }

        public void RemoveLast()
        {
            if (!(Length == 0))
            {
                Length--;
            }

            Resize(Length);
        }

        public void RemoveFirst()
        {
            RemoveByIndex(indexZero, shiftByOne);
        }

        public void RemoveByIndex(int index)
        {
            if ((index == 0 && Length == 0) || (index < Length && index >= 0))
            {
                if (!(Length == 0))
                {
                    Length--;
                    ShiftLeft(index, shiftByOne);
                }

                Resize(Length);
            }
            else
            {
                throw new IndexOutOfRangeException("Index Out Of Randge ");
            }
        }

        public void RemoveLast(int nElements)
        {
            if (nElements >= 0)
            {
                if (Length >= nElements)
                {

                    Length -= nElements;

                }
                else
                {
                    Length = 0;
                }

                Resize(Length);
            }
            else
            {
                throw new ArgumentException("Removing negative number of elements");
            }
        }

        public void RemoveFirst(int nElements)
        {
            RemoveByIndex(indexZero, nElements);
        }

        public void RemoveByIndex(int index, int nElements)
        {
            if (nElements >= 0)
            {
                if ((index == 0 && Length == 0) || (index < Length && index >= 0))
                {
                    if (Length - index >= nElements)
                    {
                        Length -= nElements;
                        ShiftLeft(index, nElements);
                    }
                    else
                    {
                        Length = index;
                    }

                    Resize(Length);
                }
                else
                {
                    throw new IndexOutOfRangeException("Index Out Of Randge ");
                }
            }
            else
            {
                throw new ArgumentException("Removing negative number of elements");
            }

        }
        //GetIndexByValue for Maksim
        // indexOf for Svyatoslav
        public int GetIndexByValue(int value)
        {
            for (int i = 0; i < Length; i++)
            {
                if (value == _array[i])
                {
                    return i;
                }
            }

            return -1;
        }

        public void Reverse()
        {
            int temp;
            int swapIndex;
            for (int i = 0; i < Length / 2; i++)
            {
                swapIndex = Length - i - 1;
                temp = _array[i];

                _array[i] = _array[swapIndex];
                _array[swapIndex] = temp;
            }
        }

        // MaxI for Svyatoslav
        // FindMaxIndex for Maksim
        public int FindMaxIndex()
        {
            if (!(Length == 0))
            {
                int maxIndexOfElement = 0;

                for (int i = 1; i < Length; i++)
                {
                    if (_array[maxIndexOfElement] < _array[i])
                    {
                        maxIndexOfElement = i;
                    }
                }

                return maxIndexOfElement;
            }

            throw new ArgumentException("empty  list");

        }


        // MinI for Svyatoslav
        // FindMinIndex for Maksim
        public int FindMinIndex()
        {
            if (!(Length == 0))
            {

                int minIndexOfElement = 0;

                for (int i = 1; i < Length; i++)
                {
                    if (_array[minIndexOfElement] > _array[i])
                    {
                        minIndexOfElement = i;
                    }
                }

                return minIndexOfElement;
            }

            throw new ArgumentException("empty  list");

        }

        // Max for Svyatoslav
        // FindMaxElement for Maksim
        public int FindMaxElement()
        {
            return _array[FindMaxIndex()];
        }

        // Min for Svyatoslav
        // FindMinElement for Maksim
        public int FindMinElement()
        {
            return _array[FindMinIndex()];
        }

        public void RemoveByValue(int value)
        {
            int index = GetIndexByValue(value);
            if (!(index == -1))
            {
                RemoveByIndex(index);
            }
        }

        public void RemoveAllByValue(int value)
        {
            int indexOfElements = GetIndexByValue(value);
            while (indexOfElements != -1)
            {
                RemoveByIndex(indexOfElements);
                indexOfElements = GetIndexByValue(value);
            }
        }

        public void SortAscendingInsert()
        {
            int j;
            int temp;
            for (int i = 1; i < Length; i++)
            {
                j = i;
                temp = _array[i];

                while (j > 0 && temp < _array[j - 1])
                {
                    _array[j] = _array[j - 1];
                    j--;
                }

                _array[j] = temp;
            }
        }

        public void SortDescendingInsert()
        {
            int j;
            int temp;
            for (int i = 1; i < Length; i++)
            {
                j = i;
                temp = _array[i];

                while (j > 0 && temp > _array[j - 1])
                {
                    _array[j] = _array[j - 1];
                    j--;
                }

                _array[j] = temp;
            }
        }
        private void Resize(int oldLength)
        {
            if ((Length >= _array.Length) || (Length <= _array.Length / 2))
            {
                int newLength = (int)(Length * 1.33d + 1);
                int[] tempArray = new int[newLength];

                for (int i = 0; i < oldLength; ++i)
                {
                    tempArray[i] = _array[i];
                }

                _array = tempArray;
            }
        }

        //shift to the right ------->
        private void ShiftRight(int index, int nElements)
        {
            for (int i = Length - 1; i > index; --i)
            {
                _array[i] = _array[i - nElements];
            }
        }

        // left shift    <-------
        private void ShiftLeft(int index, int nElements)
        {
            for (int i = index; i < Length; ++i)
            {
                _array[i] = _array[i + nElements];
            }
        }

        public override string ToString()
        {
            if (Length != 0)
            {
                string s = _array[0] + " ";

                for (int i = 1; i < Length; i++)
                {
                    s += _array[i] + " ";
                }

                return s;
            }

            return String.Empty;
        }

        public override bool Equals(object obj)
        {
            if (obj is ArrayList || obj is null)
            {
                ArrayList list = (ArrayList)obj;
             
                if (this.Length != list.Length)
                {

                    return false;
                }

                for (int i = 0; i < Length; i++)
                {
                    if (this._array[i] != list._array[i])
                    {
                        return false;
                    }
                }

                return true;
            }

            throw new ArgumentException("obj is not arrayList!");
        }

    }
}



