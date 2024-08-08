using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class Node<T>
    {
        public T Data { get; } // Auto-property for data
        public Node<T>? Left { get; set; } // Nullable reference for the left child
        public Node<T>? Right { get; set; } // Nullable reference for the right child

        // Constructor
        public Node(T data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }
}
