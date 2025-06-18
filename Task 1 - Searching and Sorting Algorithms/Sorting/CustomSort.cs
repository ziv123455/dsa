using System;
using System.Collections.Generic;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    internal class CustomSort : Sorter
    {
        /// <summary>
        /// Sorts the orders by Deliver Date in descending order (most recent first)
        /// using built-in sorting with a custom comparer.
        /// </summary>
        public override List<Order> Sort(List<Order> unsortedOrderList)
        {
            // Create a copy to avoid modifying the original list
            List<Order> sortedList = new List<Order>(unsortedOrderList);

            // Sort by deliverOn descending (most recent first)
            sortedList.Sort((order1, order2) => order2.deliverOn.CompareTo(order1.deliverOn));

            return sortedList;
        }
    }
}