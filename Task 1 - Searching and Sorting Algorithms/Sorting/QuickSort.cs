using System;
using System.Collections.Generic;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    internal class QuickSort : Sorter
    {
        public override List<Order> Sort(List<Order> unsortedOrderList)
        {
            List<Order> orders = new List<Order>(unsortedOrderList);
            QuickSortHelper(orders, 0, orders.Count - 1);
            return orders;
        }

        private void QuickSortHelper(List<Order> orders, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(orders, low, high);
                QuickSortHelper(orders, low, pivotIndex - 1);
                QuickSortHelper(orders, pivotIndex + 1, high);
            }
        }

        private int Partition(List<Order> orders, int low, int high)
        {
            Order pivot = orders[low]; // left-most pivot
            int i = low + 1;
            int j = high;

            while (true)
            {
                while (i <= j && orders[i].ID.CompareTo(pivot.ID) <= 0)
                    i++;

                while (i <= j && orders[j].ID.CompareTo(pivot.ID) > 0)
                    j--;

                if (i <= j)
                {
                    Swap(orders, i, j);
                }
                else
                {
                    break;
                }
            }

            Swap(orders, low, j);
            return j;
        }

        private void Swap(List<Order> orders, int i, int j)
        {
            Order temp = orders[i];
            orders[i] = orders[j];
            orders[j] = temp;
        }
    }
}
