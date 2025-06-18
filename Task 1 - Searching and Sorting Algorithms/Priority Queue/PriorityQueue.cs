using System;
using System.Collections.Generic;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    internal class PriorityQueue
    {
        private Heap priorityQueue;

        // Build the heap using the list of orders
        private void Build(List<Order> orders)
        {
            priorityQueue = new Heap();
            priorityQueue.Build(orders);
        }

        // Get 5 most urgent orders with earliest delivery dates
        public List<Order> GetMostUrgentOrders(List<Order> orders)
        {
            Build(orders);
            List<Order> urgentOrders = new List<Order>();

            int count = Math.Min(5, priorityQueue.Count);
            for (int i = 0; i < count; i++)
            {
                urgentOrders.Add(priorityQueue.Remove());
            }

            return urgentOrders;
        }
    }
}
