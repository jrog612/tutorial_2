/*
 * DNode: 더블 링크드 리스트의 한 요소
 *
 */


using System.Collections;
using UnityEngine;

public class DNode<T>
{
    public DNode<T> Next;
    public DNode<T> Prev;
    public T Data { get; private set; }

    public DNode(T data)
    {
        Data = data;
    }
}

public class DLinkedList<T> : IEnumerable
{
    public DNode<T> Head;
    public DNode<T> Tail;

    public void AddFirst(T value)
    {
        /*
         * AddFirst: 헤드 값의 변동
         * Head가 null일 때.
         *  - Head = newNode
         *  - Tail = newNode
         * 그게 아닐때
         *  - Head.Prev = newNode
         *  - newNode.Next = Head
         *  - Head = newNode
         */

        DNode<T> newNode = new DNode<T>(value);
        if (Head == null)
        {
            Tail = newNode;
        }
        else
        {
            Head.Prev = newNode;
            newNode.Next = Head;
        }

        Head = newNode;
    }

    public void AddLast(T value)
    {
        /*
         * AddLast: 테일 값의 변동
         * Tail이 null일 때.
         *  - Head = newNode
         *  - Tail = newNode
         * 그게 아닐때
         *  - Tail.Next = newNode
         *  - newNode.Prev = Tail
         *  - Tail = newNode
         */
        DNode<T> newNode = new DNode<T>(value);
        if (Tail == null)
        {
            Head = newNode;
        }
        else
        {
            Tail.Next = newNode;
            newNode.Prev = Tail;
        }

        Tail = newNode;
    }

    public DNode<T> Get(int index)
    {
        var current = Head;
        for (int i = 0; i < index; i++)
        {
            current = current.Next;
        }

        return current;
    }

    public DNode<T> Pop(int index)
    {
        /*
         * target 가져오기
         * target의 Prev, Next 가져오기
         * target.Prev.Next = target.Next
         * target.Next.Prev = target.Prev
         */

        var target = Get(index);
        var prev = target.Prev;
        var next = target.Next;

        prev.Next = next;
        next.Prev = prev;
        return target;
    }

    public DNode<T> Insert(int index, T value)
    {
        /*
         * Insert: index번에 있던 애는 뒤로 밀려나야 한다.
         * newNode.Next = oldNode
         * oldNode.Prev.Next = newNode
         * oldNode.Prev = newNode
         */

        var newNode = new DNode<T>(value);
        var oldNode = Get(index);
        var prev = oldNode.Prev;

        newNode.Next = oldNode;
        newNode.Prev = prev;
        oldNode.Prev = newNode;
        prev.Next = newNode;
        return newNode;
    }
    
    private void _Logging(DNode<T> node)
    {
        string prevValue = "null";
        string nextValue = "null";
        if (node.Prev != null) prevValue = $"{node.Prev.Data}";
        if (node.Next != null) nextValue = $"{node.Next.Data}";

        Debug.Log($"현재값: {node.Data} / Prev: {prevValue}/ Next: {nextValue}");
    }

    public void Traverse()
    {
        var current = Head;
        while (current != null)
        {
            _Logging(current);
            current = current.Next;
        }

        current = Tail;
        while (current != null)
        {
            _Logging(current);
            current = current.Prev;
        }
    }

    public IEnumerator GetEnumerator()
    {
        return new DLinkedEnumerator(this);
    }

    private class DLinkedEnumerator : IEnumerator
    {
        private DNode<T> currentNode;
        
        public object Current => currentNode;
        private DLinkedList<T> _list;

        public DLinkedEnumerator(DLinkedList<T> list)
        {
            _list = list;
        }

        public bool MoveNext()
        {
            if (Current == null) currentNode = _list.Head;
            else currentNode = currentNode.Next;
            return currentNode != null;
        }

        public void Reset()
        {
            currentNode = _list.Head;
        }
    }
}