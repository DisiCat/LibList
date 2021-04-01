using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryList
{
    public class LinkedList : IList
    {
        private Node _root;
        private Node _tail;

        public int Length { get; private set; }

        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < Length)
                {
                    return GetNodeByIndex(index).Value;
                }
                else
                {
                    throw new IndexOutOfRangeException("incorect index");
                }
            }

            set
            {

                if (index >= 0 && index < Length)
                {
                    GetNodeByIndex(index).Value = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("incorect index");
                }

            }
        }

        public LinkedList()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }

        public LinkedList(int value)
        {
            Length = 1;
            _root = new Node(value);
            _tail = _root;
        }

        private LinkedList(int[] values)
        {
                Length = 0;

                if (values.Length != 0)
                {
                    for (int i = 0; i < values.Length; ++i)
                    {
                        AddLast(values[i]);
                    }
                }
                else
                {
                    _root = null;
                    _tail = null;
                }
        }

        public static LinkedList Create(int[] values)
        {
            if (!(values is null))
            {
                return new LinkedList(values);
            }

            throw new ArgumentException(" Array is Null");
        }

        public void AddLast(int value)
        {
            if (Length != 0)
            {
                _tail.Next = new Node(value);
                _tail = _tail.Next;
            }
            else
            {
                _root = new Node(value);
                _tail = _root;
            }

            ++Length;
        }

        public void AddLast(IList obj)
        {
            if (!(obj is null))
            {
                LinkedList list = LinkedList.Create(obj.ToArray());
                for (int i = 0; i < list.Length; i++)
                {
                    AddLast(list[i]);
                }
            }
            else
            {
                throw new ArgumentNullException(" List is null");
            }
        }

        public void AddFirst(int value)
        {
            Node first = new Node(value);

            first.Next = _root;
            _root = first;

            if (Length == 0)
            {
                _tail = _root;
            }

            Length++;
        }

        public void AddFirst(IList obj)
        {
            if (!(obj is null))
            {
                LinkedList list = LinkedList.Create(obj.ToArray());
             
                for (int i = list.Length - 1; i >= 0; --i)
                {
                    AddFirst(list[i]);
                }
            }
            else
            {
                throw new ArgumentNullException(" List is null");
            }
        }

        public void AddByIndex(int index, int value)
        {
            if ((index == Length && Length == 0) || (index >= 0 && index < Length))
            {
                if (index != 0)
                {
                    Node ByIndex = new Node(value);

                    Node current = GetNodeByIndex(index - 1);

                    ByIndex.Next = current.Next;
                    current.Next = ByIndex;

                    Length++;
                }
                else
                {
                    AddFirst(value);
                }
            }
            else
            {
                throw new IndexOutOfRangeException("Index out of range!");
            }
        }

        public void AddByIndex(int index, IList obj)
        {
            if (!(obj is null))
            {
                if ((index == Length && Length == 0) || (index >= 0 && index < Length))
                {
                    LinkedList newList = LinkedList.Create(obj.ToArray());

                    if (index != 0)
                    {
                        if (newList.Length != 0)
                        {
                            Node current = GetNodeByIndex(index - 1);

                            newList._tail.Next = current.Next;
                            _tail = current;
                            int newLengthList = newList.Length + Length - index;
                            newList.Length += Length - index;
                            Length = index;

                            for (int i = 0; i < newLengthList; i++)
                            {
                                AddLast(newList[i]);
                            }

                            newList._tail.Next = null;

                        }
                    }
                    else
                    {
                        AddFirst(newList);
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            else
            {
                throw new ArgumentNullException(" obj is null");
            }
        }

        public void RemoveLast()
        {
            if (Length != 0)
            {
                RemoveByIndex(Length - 1);
            }
        }

        public void RemoveFirst()
        {
            if (Length != 0)
            {
                _root = _root.Next;
                --Length;
            }
        }

        public void RemoveByIndex(int index)
        {
            if ((index == Length && Length == 0) || (index >= 0 && index < Length))
            {
                if (index != 0)
                {

                    Node current = GetNodeByIndex(index - 1);

                    current.Next = current.Next.Next;

                    if (current.Next is null)
                    {
                        _tail = current;

                    }
                    --Length;
                }
                else
                {
                    if (Length != 0)
                    {
                        _root = _root.Next;
                        --Length;
                    }
                }

            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void RemoveLast(int count)
        {
            if (count >= 0)
            {
                if (Length != 0 && count != 0)
                {
                    if (Length - count > 0)
                    {
                        Length -= count;
                        _tail = GetNodeByIndex(Length - 1);
                        _tail.Next = null;
                    }
                    else
                    {
                        Length = 0;
                        _root = null;
                        _tail = null;
                    }
                }
            }
            else
            {
                throw new ArgumentException("Wrong arguments");
            }
        }

        public void RemoveFirst(int count)
        {
            if (count >= 0)
            {
                if (Length != 0 && count != 0)
                {
                    if (Length - count > 0)
                    {
                        _root = GetNodeByIndex(count);
                        Length -= count;
                    }
                    else
                    {
                        Length = 0;
                        _root = null;
                        _tail = null;
                    }
                }
            }
            else
            {
                throw new ArgumentException("Wrong arguments");
            }

        }

        public void RemoveByIndex(int index, int count)
        {
            if (count >= 0)
            {

                if (index >= 0 && index < Length)
                {
                    if (Length != 0 || count != 0)
                    {
                        if (index != 0)
                        {
                            if (Length - index - count > 0)
                            {
                                Node sectionStart = GetNodeByIndex(index - 1);
                                Node sectionEnd = GetNodeByIndex(index + count);

                                sectionStart.Next = sectionEnd;
                                Length -= count;
                            }
                            else
                            {
                                Node sectionStart = GetNodeByIndex(index - 1);
                                sectionStart.Next = null;
                                _tail = sectionStart;
                                Length = index;
                            }
                        }
                        else
                        {
                            RemoveFirst(count);
                        }
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException("incotrect index");
                }
            }
            else
            {
                throw new ArgumentException("Wrong arguments");
            }
        }

        //GetIndexByValue for Maksim
        // indexOf for Svyatoslav
        public int GetIndexByValue(int value)
        {
            Node currentNode = _root;

            for (int i = 0; i < Length; ++i)
            {
                if (currentNode.Value == value)
                {
                    return i;
                }

                currentNode = currentNode.Next;
            }

            return -1;
        }

        public void Reverse()
        {
            if (!(this is null))
            {
                if (Length > 1)
                {
                    _tail.Next = _root;
                    Node stepByOne = _root.Next;
                    Node stepBySecond = _root.Next.Next;
                    _root.Next = null;
                    while (!(stepBySecond is null))
                    {
                        if (stepBySecond.Next is null)
                        {
                            _tail = _tail.Next;
                        }

                        stepByOne.Next = _root;
                        _root = stepByOne;
                        stepByOne = stepBySecond;
                        stepBySecond = stepBySecond.Next;
                    };
                }
            }
        }

        //// MaxI for Svyatoslav
        //// FindMaxIndex for Maksim
        public int FindMaxIndex()
        {
            if (Length != 0 || this is null)
            {
                Node current = _root;
                int maxIndex = 0;
                int maxValue = _root.Value;

                for (int i = 1; i < Length; i++)
                {
                    if (maxValue < current.Next.Value)
                    {
                        maxValue = current.Next.Value;
                        maxIndex = i;
                    }

                    current = current.Next;
                }

                return maxIndex;
            }

            throw new ArgumentException("List is null");
        }

        //// MinI for Svyatoslav
        //// FindMinIndex for Maksim
        public int FindMinIndex()
        {
            if (Length != 0 || this is null)
            {
                Node current = _root;
                int minIndex = 0;
                int minValue = _root.Value;

                for (int i = 1; i < Length; i++)
                {
                    if (minValue > current.Next.Value)
                    {
                        minValue = current.Next.Value;
                        minIndex = i;
                    }

                    current = current.Next;
                }

                return minIndex;
            }

            throw new ArgumentException("List is null");
        }


        // Max for Svyatoslav
        // FindMaxElement for Maksim
        public int FindMaxElement()
        {
            if (Length != 0 || this is null)
            {
                Node current = _root;
                int maxValue = _root.Value;

                for (int i = 1; i < Length; i++)
                {
                    if (maxValue < current.Next.Value)
                    {
                        maxValue = current.Next.Value;
                    }

                    current = current.Next;
                }

                return maxValue;
            }

            throw new ArgumentException("List is null");
        }

        //// Min for Svyatoslav
        //// FindMinElement for Maksim
        public int FindMinElement()
        {
            if (Length != 0 || this is null)
            {
                Node current = _root;
                int minValue = _root.Value;

                for (int i = 1; i < Length; i++)
                {
                    if (minValue > current.Next.Value)
                    {
                        minValue = current.Next.Value;
                    }

                    current = current.Next;
                }

                return minValue;
            }

            throw new ArgumentException("List is null");
        }

        public void RemoveByValue(int value)
        {
            int index = GetIndexByValue(value);

            if (index != -1)
            {
                RemoveByIndex(index);
            }

        }

        public void RemoveAllByValue(int value)
        {
            int index = GetIndexByValue(value);

            while (index != -1)
            {
                RemoveByIndex(index);
                index = GetIndexByValue(value);
            }

        }



        public void Sort(bool isDescending)
        {
            if (!(this is null))
            {
                Node new_root = null;
                    while (_root != null)
                    {
                        Node node = _root;
                        _root = _root.Next;

                        if ( new_root == null ||  (node.Value > new_root.Value && !isDescending ) ||  (node.Value < new_root.Value && isDescending) )
                        {
                            node.Next = new_root;
                            
                            if (node.Next is null)
                            {
                                _tail = node;
                            }

                            new_root = node;

                        }
                        else
                        {
                            Node current = new_root;

                            while ((current.Next != null && !(node.Value > current.Next.Value) && !isDescending) || (current.Next != null && !(node.Value < current.Next.Value) && isDescending))
                            {
                                current = current.Next;
                            }

                            node.Next = current.Next;

                            if (node.Next is null)
                            {
                                _tail = node;
                            }

                            current.Next = node;
                        }
                    }

                _root = new_root;
            }
            else
            {
                throw new NullReferenceException(" List is null!");
            }
        }

        public int[] ToArray()
        {
            int[] arr = new int[Length];
            int count = 0;
            Node current = _root;
            while(!(current is null))
            {
                arr[count] = current.Value;
                ++count;
                current = current.Next;
            }

            return arr;
        }
        public override string ToString()
        {
            Node current = _root;
            StringBuilder stringBulder = new StringBuilder();

            while (!(current is null))
            {
                stringBulder.Append($"{current.Value} ");
                current = current.Next;
            }

            return stringBulder.ToString().Trim();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is null) || obj is LinkedList)
            {
                LinkedList list = (LinkedList)obj;
                bool isEqual = false;

                if (this.Length == list.Length)
                {
                    isEqual = true;
                    Node currentThis = this._root;
                    Node currentList = list._root;

                    while (!(currentThis is null))
                    {
                        if (currentThis.Value != currentList.Value)
                        {
                            isEqual = false;
                            break;
                        }
                        currentThis = currentThis.Next;
                        currentList = currentList.Next;
                    }
                }

                return isEqual;
            }

            throw new ArgumentException("obj is not LinkedList");
        }

        private Node GetNodeByIndex(int index)
        {
            if (index >= 0 && index < Length)
            {
                Node current = _root;

                for (int i = 1; i <= index; i++)
                {
                    current = current.Next;
                }

                return current;
            }

            throw new IndexOutOfRangeException("Index out of range");
        }
    }
}




