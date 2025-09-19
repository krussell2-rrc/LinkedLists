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
                throw new ApplicationException("List is empty");

            return Head.Element!;
        }

        public T GetLast()
        {
            if (Tail == null)
                throw new ApplicationException("List is empty");

            return Tail.Element!;
        }

        public T SetFirst(T element)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            if (Head == null)
                throw new ApplicationException("List is empty");

            T oldElement = Head.Element!;
            Head.Element = element;

            return oldElement;
        }

        public T SetLast(T element)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            if (Tail == null)
                throw new ApplicationException("List is empty");

            T oldElement = Tail.Element!;
            Tail.Element = element;

            return oldElement;
        }

        public void AddFirst(T element)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

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

        public void AddLast(T element)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            Node<T> newNode = new Node<T>(element);

            if (Tail == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                newNode.PreviousNode = Tail;
                Tail.NextNode = newNode;
                Tail = newNode;
            }

            Size++;
        }

        public T RemoveFirst()
        {
            if (Head == null)
                throw new ApplicationException("List is empty");

            var oldNodeElement = Head.Element!;

            if (Size == 1)
            {
                Head = null;
                Tail = null;

            }
            else
            {
                Head = Head.NextNode;
                Head!.PreviousNode = null;
            }

            Size--;
            return oldNodeElement;
        }

        public T RemoveLast()
        {
            if (Tail == null)
                throw new ApplicationException("List is empty");

            var oldNodeElement = Tail.Element!;

            if (Size == 1)
            {
                Head = null;
                Tail = null;

            }
            else
            {
                var newTail = Tail.PreviousNode;
                newTail!.NextNode = null;
                Tail = newTail;
            }

            Size--;
            return oldNodeElement;
        }

        public T Get(int position)
        {
            if (position <= 0 || position > Size)
                throw new ApplicationException("The position can not be negative, 0 or higher than the size of the list");

            var node = Head!;

            for (int i = 1; i < position; i++)
                node = node.NextNode!;

            return node.Element!;
        }

        public T Remove(int position)
        {
            if (position <= 0 || position > Size)
                throw new ApplicationException("The position can not be negative, 0 or higher than the size of the list");

            var node = Head!;

            for (int i = 1; i < position; i++)
                node = node.NextNode!;

            var removedNodeElement = node.Element!;

            if(Size == 1)
            {
                Head = null;
                Tail = null;
                Size--;

                return removedNodeElement;
            }
            else if (position == 1)
            { 
                Head = Head!.NextNode;
                Head!.PreviousNode = null;
            }
            else if (position == Size)
            {
                Tail = Tail!.PreviousNode;
                Tail!.NextNode = null;
            }
            else
            {
                node.PreviousNode!.NextNode = node.NextNode;
                node.NextNode!.PreviousNode = node.PreviousNode;
            }

            Size--;

            return removedNodeElement;
        }

        public T Set(T element, int position)
        {
            if (position <= 0 || position > Size)
                throw new ApplicationException("The position can not be negative, 0 or higher than the size of the list");

            if (element == null)
                throw new ArgumentNullException(nameof(element));

            var node = Head!;

            for (int i = 1; i < position; i++)
                node = node.NextNode!;

            var oldElement = node.Element!;
            node.Element = element;

            return oldElement;
        }

        public void AddAfter(T element, int position)
        {
            if (position <= 0 || position > Size)
                throw new ApplicationException("The position can not be negative, 0 or higher than the size of the list");

            if (element == null)
                throw new ArgumentNullException(nameof(element));

            var node = Head!;

            for (int i = 1; i < position; i++)
                 node = node.NextNode!;

            var next = node.NextNode;

            Node<T> newNode = new Node<T>(element);

            newNode.PreviousNode = node;
            newNode.NextNode = next;

            node.NextNode = newNode;

            if (next != null)
            {
                next.PreviousNode = newNode;
            }
            else
            {
                Tail = newNode;
            }

            Size++;
        }

        public void AddBefore(T element, int position)
        {
            if (position <= 0 || position > Size)
                throw new ApplicationException("The position can not be negative, 0 or higher than the size of the list");

            if (element == null)
                throw new ArgumentNullException(nameof(element));

            var node = Head!;

            for (int i = 1; i < position; i++)
                node = node.NextNode!;

            var previous = node.PreviousNode;

            Node<T> newNode = new Node<T>(element);

            newNode.NextNode = node;
            newNode.PreviousNode = previous;

            node.PreviousNode = newNode;

            if (previous != null)
            {
                previous.NextNode = newNode;
            }
            else
            {
                Head = newNode;
            }

            Size++;
        }
    }
}
