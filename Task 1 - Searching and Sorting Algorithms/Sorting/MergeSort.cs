using System;
using System.Collections.Generic;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    internal class MergeSort : Sorter
    {
        public override List<Order> Sort(List<Order> unsortedOrderList)
        {
            if (unsortedOrderList.Count <= 1)
                return new List<Order>(unsortedOrderList);

            return MergeSortHelper(unsortedOrderList);
        }

        private List<Order> MergeSortHelper(List<Order> list)
        {
            if (list.Count <= 1)
                return list;

            int mid = list.Count / 2;
            List<Order> left = MergeSortHelper(list.GetRange(0, mid));
            List<Order> right = MergeSortHelper(list.GetRange(mid, list.Count - mid));

            return Merge(left, right);
        }

        private List<Order> Merge(List<Order> left, List<Order> right)
        {
            List<Order> result = new List<Order>();
            int i = 0, j = 0;

            while (i < left.Count && j < right.Count)
            {
                // Most recent first: placedOn descending order
                if (left[i].placedOn >= right[j].placedOn)
                {
                    result.Add(left[i]);
                    i++;
                }
                else
                {
                    result.Add(right[j]);
                    j++;
                }
            }

            while (i < left.Count)
            {
                result.Add(left[i]);
                i++;
            }

            while (j < right.Count)
            {
                result.Add(right[j]);
                j++;
            }

            return result;
        }
    }
}
