using System;
using System.Collections.Generic;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    internal class BinarySearchTree
    {
        // Use the provided TreeNode class
        public TreeNode Root { get; private set; }

        /// <summary>
        /// Builds the BST from the list of orders
        /// </summary>
        public void Build(List<Order> Orders)
        {
            if (Orders == null || Orders.Count == 0)
            {
                Root = null;
                return;
            }

            Root = new TreeNode(Orders[0]);

            for (int i = 1; i < Orders.Count; i++)
            {
                Insert(Root, Orders[i]);
            }
        }

        // Inserts an order in the BST recursively
        private void Insert(TreeNode currentNode, Order order)
        {
            if (order.ID.CompareTo(currentNode.order.ID) < 0)
            {
                if (currentNode.Left == null)
                    currentNode.Left = new TreeNode(order);
                else
                    Insert(currentNode.Left, order);
            }
            else
            {
                if (currentNode.Right == null)
                    currentNode.Right = new TreeNode(order);
                else
                    Insert(currentNode.Right, order);
            }
        }

        /// <summary>
        /// Searches for an order by ID in the BST
        /// </summary>
        public Order Get(Guid orderID)
        {
            return Search(Root, orderID);
        }

        // Recursively searches the BST for the order ID
        private Order Search(TreeNode currentNode, Guid orderID)
        {
            if (currentNode == null)
                return null;

            int comparison = orderID.CompareTo(currentNode.order.ID);

            if (comparison == 0)
                return currentNode.order;
            else if (comparison < 0)
                return Search(currentNode.Left, orderID);
            else
                return Search(currentNode.Right, orderID);
        }
    }
}
