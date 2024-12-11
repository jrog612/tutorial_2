using System;
using System.Collections.Generic;

public class PriorityQueue
{
    private List<int> heap = new ();

    public void Enqueue(int item)
    {
        heap.Add(item);
        int currentIndex = heap.Count - 1;
        HeapifyUp(currentIndex);
    }

    public int Dequeue()
    {
        if (heap.Count == 0)
            throw new InvalidOperationException("우선순위 큐가 비어있습니다.");

        int root = heap[0];
        int lastIndex = heap.Count - 1;
        heap[0] = heap[lastIndex];
        heap.RemoveAt(lastIndex);

        if (heap.Count > 0)
            HeapifyDown(0);

        return root;
    }

    private void HeapifyUp(int index)
    {
        while (index > 0)
        {
            int parentIndex = (index - 1) / 2;
            if (heap[index] - heap[parentIndex] >= 0)
                break;

            Swap(index, parentIndex);
            index = parentIndex;
        }
    }

    private void HeapifyDown(int index)
    {
        int lastIndex = heap.Count - 1;
        while (true)
        {
            int smallest = index;
            int leftChild = 2 * index + 1;
            int rightChild = 2 * index + 2;

            if (leftChild <= lastIndex && heap[leftChild] - heap[smallest] < 0)
                smallest = leftChild;
            if (rightChild <= lastIndex && heap[rightChild] - heap[smallest] < 0)
                smallest = rightChild;

            if (smallest == index)
                break;

            Swap(index, smallest);
            index = smallest;
        }
    }

    private void Swap(int i, int j) => (heap[i], heap[j]) = (heap[j], heap[i]);

    public int Count => heap.Count;
    public bool IsEmpty => heap.Count == 0;
}