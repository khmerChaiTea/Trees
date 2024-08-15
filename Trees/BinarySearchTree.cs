using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Trees
{
    public class BinarySearchTree
    {
        private Node<int>? Root;
        private int Count = 0;

        public void DeleteNode(int valueToDelete)
        {
            (var valueExist, var node, var priorNode) = DoesValueExist(valueToDelete);
            if (!valueExist) return;

            // Run the delete logic
            if (node.Left != null)
            {
                // head down the left hand side - grab the largest value
                var secondLargestNode = node.Left;

                if (secondLargestNode.Right == null)
                {
                    // If there are no right hand note then we know we reached the largest node
                }

                while (secondLargestNode.Right.Right != null)
                {
                    secondLargestNode = secondLargestNode.Right;
                }

                node.Data = secondLargestNode.Right.Data;
                secondLargestNode.Right = null;
            }
            else if (node.Right != null)
            {
                // head down the right hand side - grab the smallest value
            }
            else
            {
            }
        }

        public (bool valueExist, Node<int>? node, Node<int>? predecessor) DoesValueExist(int valueToFind)
        {
            Node<int>? currentNode = Root;
            Node<int>? priorNode = null;

            while (currentNode != null)
            {
                if (currentNode.Data == valueToFind)
                    return (true, currentNode, priorNode);
                else if (valueToFind <= currentNode.Data)
                {
                    priorNode = currentNode;
                    currentNode = currentNode.Left;
                }
                else
                {
                    currentNode = currentNode.Right;
                }
            }

            return (false, null, null);
        }

        public void Insert(int data)
        {
            Node<int> newNode = new Node<int>(data);
            if (Root == null)
            {
                Root = newNode;
                Count++;
            }
            else
            {
                InsertHelper(newNode, Root);
            }
        }

        // Helper function
        private void InsertHelper(Node<int> newNode, Node<int> currentNode)
        {
            if (currentNode == null)
            {
                throw new ArgumentNullException(nameof(currentNode), "currentNode cannot be null.");
            }

            // Go left
            if (newNode.Data <= currentNode.Data)
            {
                if (currentNode.Left == null)
                {
                    currentNode.Left = newNode;
                    Count++;
                }
                else
                {
                    InsertHelper(newNode, currentNode.Left);
                }
            }
            // Go right
            else
            {
                if (currentNode.Right == null)
                {
                    currentNode.Right = newNode;
                    Count++;
                }
                else
                {
                    InsertHelper(newNode, currentNode.Right);
                }
            }
        }
    }
}
