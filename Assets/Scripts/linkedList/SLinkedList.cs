using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node<T>
{
    public T Data { get; set; }
    public Node<T> Next { get; set; }

    public Node(T data)
    {
        Data = data;
        Next = null;
    }

    public bool HasNext()
    {
        return Next != null;
    }
}

public class SLinkedList<T>
{
    public Node<T> Head { get; private set; }

    public void AddLast(T data)
    {
        var newNode = new Node<T>(data);

        if (Head == null)
        {
            Head = newNode;
        }
        else
        {
            var curNode = Head;
            while (curNode.HasNext())
            {
                curNode = curNode.Next;
            }

            curNode.Next = newNode;
        }
    }

    public void AddFirst(T data)
    {
        var newNode = new Node<T>(data);
        newNode.Next = Head;
        Head = newNode;
    }

    public Node<T> SearchIndex(int index)
    {
        var curNode = Head;
        if (Head == null) return null;
        for (var j = 0; j <= index; j++)
        {
            curNode = Head.Next;
        }

        return curNode;
    }

    public void Traverse()
    {
        var current = Head;
        while (current != null)
        {
            Debug.Log(current.Data);
            current = current.Next;
        }
    }
}