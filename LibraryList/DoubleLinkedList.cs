using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryList
{
    public class DoubleLinkedList
    {
        private DoubleNode _root;
        private DoubleNode _tail;

        public int Length { get; private set; }
        public int this[int index]
        {
            get
            {
                return GetNodeByIndex(index).Value;
            }
            set
            {
                GetNodeByIndex(index).Value = value;
            }
        }

        public DoubleLinkedList()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }
        public DoubleLinkedList(int value)
        {
            Length = 1;
            _root = new DoubleNode(value);
            _tail = _root;
        }

        public DoubleLinkedList(int[] values)
        {
            if (!(values is null))
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
            else
            {
                throw new ArgumentException(" Array is Null");
            }
        }

        public void AddLast(int value)
        {
            if (Length != 0)
            {
                DoubleNode current = _tail;
                _tail.Next = new DoubleNode(value);
                _tail = _tail.Next;
                _tail.Previous = current;
            }
            else
            {
                _root = new DoubleNode(value);
                _tail = _root;
            }

            ++Length;
        }

        public void AddLast(DoubleLinkedList list)
        {
            if (!(list is null))
            {
                DoubleNode current = list._root;
                int value = 0;

                while (!(current is null))
                {
                    value = current.Value;
                    AddLast(value);
                    current = current.Next;
                }
            
            }
            else
            {
                throw new ArgumentException(" List is null");
            }
        }
        public void AddFirst(int value)
        {
            DoubleNode first = new DoubleNode(value);

            if (Length != 0)
            {
                first.Next = _root;
                _root.Previous = first;
                _root = first;

            }
            else
            {
                first.Next = _root;
                _root = first;
                _tail = _root;
            }

            Length++;
        }

        public void AddFirst(DoubleLinkedList list)
        {
            if (!(list is null))
            {
                DoubleNode current = list._tail;
                int value = 0;

                while(!(current is null))
                {
                    value = current.Value;
                    AddFirst(value);
                    current = current.Previous;
                }

            }
            else
            {
                throw new ArgumentException(" List is null");
            }
        }

        public void AddByIndex(int index, int value)
        {
            if ((index == Length && Length == 0) || (index >= 0 && index < Length))
            {
                if (index != 0)
                {
                    DoubleNode ByIndex = new DoubleNode(value);

                    DoubleNode current = GetNodeByIndex(index);

                    InsertNode(ByIndex, current);

                    //ByIndex.Next = current;
                    //ByIndex.Previous = current.Previous;

                    //current.Previous.Next = ByIndex;
                    //current.Previous = ByIndex;
                    
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

        public void AddByIndex(int index, DoubleLinkedList newList)
        {
            if ((index == Length && Length == 0) || (index >= 0 && index < Length))
            {
                if (index != 0)
                {
                    if (newList.Length != 0)
                    {
                        DoubleNode current = GetNodeByIndex(index);
                        DoubleNode NewList = newList._root;

                        for (int i = 0; i < newList.Length; i++)
                        {
                            DoubleNode currentNewList = new DoubleNode(NewList.Value);

                            InsertNode(currentNewList, current);

                            NewList = NewList.Next;
                            ++Length;

                            //currentNewList.Next = current;
                            //currentNewList.Previous = current.Previous;
                            //current.Previous.Next = currentNewList;
                            //current.Previous = currentNewList;
                        }
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

        public void RemoveLast()
        {
            if (Length !=0)
            {
                RemoveByIndex(Length - 1);
            } 
        }

        public void RemoveFirst()
        {
            if (Length > 1)
            {
                _root = _root.Next;
                _root.Previous = null;
                --Length;
            }
            else if (Length == 1)
            {
                _root = _root.Next;
                _tail = null;
                --Length;
            }
        }

        public void RemoveByIndex(int index)
        {
            if ((index == Length && Length == 0) || (index >= 0 && index < Length))
            {
                if (index != 0)
                {
                    if (Length != 1)
                    {
                        DoubleNode current = GetNodeByIndex(index - 1);

                        current.Next = current.Next.Next;
                        
                        if(current.Next is null)
                        {
                        _tail = current;

                        }
                    }
                    else
                    {
                        _root = null;
                        _tail = null;
                    }
                    --Length;
                }
                else
                {
                    this.RemoveFirst();
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
                    if (Length - count >= 0)
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
                    if (Length - count >= 0)
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
            if ((index >= 0 && index < Length) && count >= 0)
            {
                if (Length != 0 || count != 0)
                {
                    if (index != 0)
                    {
                        if (Length - index - count > 0)
                        {
                            DoubleNode sectionStart = GetNodeByIndex(index - 1);
                            DoubleNode sectionEnd = GetNodeByIndex(index + count);

                            sectionStart.Next = sectionEnd;
                            sectionEnd.Previous = sectionStart;
                            Length -= count;
                        }
                        else
                        {
                            DoubleNode sectionStart = GetNodeByIndex(index - 1);
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
                throw new ArgumentException("Wrong arguments");
            }
        }

        //GetIndexByValue for Maksim
        // indexOf for Svyatoslav
        public int GetIndexByValue(int value)
        {
            DoubleNode currentNode = _root;

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
                    DoubleNode stepByOne = _root.Next;

                    _root.Previous = stepByOne;
                    _root.Next = null;

                    while (stepByOne != _tail)
                    {
                        DoubleNode tmp = stepByOne.Next;
                        stepByOne.Next = stepByOne.Previous;
                        stepByOne.Previous = tmp;

                        stepByOne =  stepByOne.Previous;
                    };

                    stepByOne.Next = stepByOne.Previous;
                    stepByOne.Previous = null;
                    _tail = _root;
                    _root = stepByOne;
                }
            }
        }

        public void Sort(bool isDescending)
        {
            if (!(this is null))
            {
                DoubleNode new_root = null;

                while (_root != null)
                {
                    DoubleNode node = _root;
                    _root = _root.Next;

                    if (new_root == null || (node.Value > new_root.Value && isDescending) || (node.Value < new_root.Value && !isDescending))
                    {
                        node.Next = new_root;
                        node.Previous = null;

                        if (node.Next is null)
                        {
                            _tail = node;
                        }
                        else
                        {
                            node.Next.Previous = node;
                        }

                        new_root = node;

                    }
                    else
                    {
                        DoubleNode current = new_root;

                        while ((current.Next != null && !(node.Value > current.Next.Value) && isDescending) || (current.Next != null && !(node.Value < current.Next.Value) && !isDescending))
                        {
                            current = current.Next;
                        }

                        node.Next = current.Next;

                        if (node.Next is null)
                        {
                            _tail = node;
                        }
                        else
                        {
                            node.Next.Previous = node;
                        }

                        current.Next = node;
                        node.Previous = current;

                    }
                }

                _root = new_root;
            }
        }

        public override string ToString()
        {
            if (Length != 0)
            {
                DoubleNode current = _root;
                string s = current.Value + " ";

                while (!(current.Next is null))
                {
                    current = current.Next;
                    s += current.Value + " ";
                }

                return s;
            }

            return String.Empty;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is null) || obj is DoubleLinkedList)
            {
                DoubleLinkedList list = (DoubleLinkedList)obj;
                bool isEqual = false;

                if (this.Length == list.Length)
                {
                    isEqual = true;
                    DoubleNode currentThis = this._root;
                    DoubleNode currentList = list._root;
                    DoubleNode currentPrevThis = this._tail;
                    DoubleNode currentPrevList = list._tail;

                    while (!(currentThis is null))
                    {
                        if (currentThis.Value != currentList.Value && currentPrevThis.Value != currentPrevList.Value)
                        {
                            isEqual = false;
                            break;
                        }

                        currentThis = currentThis.Next;
                        currentList = currentList.Next;
                        currentPrevThis = currentPrevThis.Previous;
                        currentPrevList = currentPrevList.Previous;

                    }
                }

                return isEqual;
            }

            throw new ArgumentException("obj is not LinkedList");
        }

        private void InsertNode(DoubleNode newNode, DoubleNode current)
        {
            newNode.Next = current;
            newNode.Previous = current.Previous;
            current.Previous.Next = newNode;
            current.Previous = newNode;

        }

        private DoubleNode GetNodeByIndex(int index)
        {
            if (index >= 0 || index < Length)
            {
                DoubleNode current ;

                if (index <= Length - 1 / 2)
                {
                   current = _root;

                    for (int i = 1; i <= index; i++)
                    {
                        current = current.Next;
                    }
                }
                else
                {
                    current = _tail;

                    for (int i = Length-2; i <= index; i--)
                    {
                        current = current.Previous;
                    }
                }

                return current;

            }

            throw new IndexOutOfRangeException("Index out of range");
        }
    }
}
