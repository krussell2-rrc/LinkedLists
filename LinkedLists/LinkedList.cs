using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    internal class LinkedList<T> where T : IComparable<T>
    {
       public int Size { get; set; }
       public Node<T>? Head { get; set; }
       public Node<T>? Tail { get; set; }

        public LinkedList()
        {
            Size = 0;
            Head = null;
            Tail = null;
        }
        
        public void Clear()
        {
            Size = 0;
            Head = null;
            Tail = null;
        }

        public bool IsEmpty() => Size == 0;

        public T GetFirst()
        {
            if (Head == null)
                throw new InvalidOperationException("List is empty.");

            return Head.Element!;
        }

        public T GetLast()
        {
            if (Tail == null)
                throw new InvalidOperationException("List is empty.");

            return Tail.Element!;
        }

        public T SetFirst(T element)
        {
            if (Head == null) 
                throw new InvalidOperationException("List is empty");

            T oldElement = Head.Element!;
            Head.Element = element;

            return oldElement;
        }

        public T SetLast(T element)
        {
            if (Tail == null)
                throw new InvalidOperationException("List is empty");

            T oldElement = Tail.Element!;
            Tail.Element = element;

            return oldElement;
        }

        public void AddFirst(T element)
        {
            Node<T> newNode = new Node<T>(element);

            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                newNode.NextNode = Head;
                Head.PreviousNode = newNode;
                Head = newNode;
            }

            Size++;
        }
    }
}
