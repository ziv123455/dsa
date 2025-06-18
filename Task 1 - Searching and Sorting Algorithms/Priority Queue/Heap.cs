using System;
using System.Collections.Generic;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    internal class Heap
    {
        private List<Order> heap;

        public Heap()
        {
            heap = new List<Order>();
        }

        // Inserts an order into the heap (min-heap based on deliverOn)
        public void Insert(Order order)
        {
            heap.Add(order);
            HeapifyUp(heap.Count - 1);
        }

        // Removes and returns the order with the earliest deliverOn date (root of the min-heap)
        public Order Remove()
        {
            if (heap.Count == 0)
                throw new InvalidOperationException("Heap is empty.");

            Order root = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            HeapifyDown(0);

            return root;
        }

        // Build heap from a list of orders (O(n log n) worst case)
        public void Build(List<Order> orders)
        {
            heap = new List<Order>();
            foreach (var order in orders)
            {
                Insert(order);
            }
        }

        private void HeapifyUp(int index)
        {
            int parent = (index - 1) / 2;
            while (index > 0 && heap[index].deliverOn < heap[parent].deliverOn)
            {
                Swap(index, parent);
                index = parent;
                parent = (index - 1) / 2;
            }
        }

        private void HeapifyDown(int index)
        {
            int smallest = index;
            int leftChild = 2 * index + 1;
            int rightChild = 2 * index + 2;

            if (leftChild < heap.Count && heap[leftChild].deliverOn < heap[smallest].deliverOn)
                smallest = leftChild;

            if (rightChild < heap.Count && heap[rightChild].deliverOn < heap[smallest].deliverOn)
                smallest = rightChild;

            if (smallest != index)
            {
                Swap(index, smallest);
                HeapifyDown(smallest);
            }
        }

        private void Swap(int i, int j)
        {
            Order temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }

        public int Count => heap.Count;
    }
}
