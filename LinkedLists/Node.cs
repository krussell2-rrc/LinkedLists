using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    internal class Node<T>
    {
        public T? Element { get; set; }
        public Node<T>? PreviousNode { get; set; }
        public Node<T>? NextNode { get; set; }

        public Node()
        {
            Element = default;
            PreviousNode = null;
            NextNode = null;
        }

        public Node(T element)
        {
            Element = element;
            PreviousNode = null;
            NextNode = null;
        }

        public Node(T element, Node<T> previousNode, Node<T> nextNode)
        {
            Element = element;
            PreviousNode = previousNode;
            NextNode = nextNode;
        }
    }
}
