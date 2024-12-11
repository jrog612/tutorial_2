/*
 * Queue는 왜 쓸까?
 * - 목적, 용도, 하는 일, 원리
 * - 목적: 제일 앞에 있는 데이터부터 순차적으로 처리하기 위해서
 * - 데이터 줄세우기
 *
 * Queue에서 필요한 기능은?
 * - 데이터 추가
 * - 데이터 뽑기(가장 오래된 것 부터)
 * - 사이즈 가져오기
 * - 현재 맨 앞에 있는 데이터 조회
 * - 갯수 제한 (N개 이상 들어올 수 없음)
 * - 데이터 반전
 * - 전체 순차조회
 */

using UnityEngine;

public class QueueNode<T>
{
    public T Data { get; }
    public QueueNode<T> Next { get; set; }

    public QueueNode(T data)
    {
        Data = data;
    }
}

public class CQueue<T> where T : new()
{
    /*
     * First 가 가리키는 것은 0번째 노드 하나.
     * Last 가 가장 오래된 노드.
     * [F]<-[]<-[]<-[]<-[]<-[]<-[L]
     *
     */

    private QueueNode<T> First;
    private QueueNode<T> Last;

    private int size;
    private int maximum;

    public CQueue(int maximum = -1)
    {
        this.maximum = maximum;
    }

    public void Enqueue(T data)
    {
        /*
         * Enqueue 할 때의 과정
         * Enqueue
           newNode를 만든다.
           First.Next = newNode
           [N]<-[F]<-
           First를 newNode로 옮긴다.
           [F]<-[PF]<-
         */
        if (maximum > 0 && size >= maximum) throw new System.Exception("Queue is full");

        var newNode = new QueueNode<T>(data);
        if (First == null) Last = newNode;
        else First.Next = newNode;
        First = newNode;
        size++;
    }

    public T Dequeue()
    {
        /*
         * Dequeue -> T
           [F]<-[]<-[]<-[]<-[]<-[]<-[L]
           var tmp = Last
           Last = tmp.Next
           [F]<-[]<-[]<-[]<-[]<-[L]<-[]
           tmp.Next = null
           [F]<-[]<-[]<-[]<-[]<-[L] [t]
           return tmp.Data
         */

        if (Last == null) throw new System.Exception("Queue is empty");
        var tmp = Last;
        Last = tmp.Next;
        tmp.Next = null;
        size--;
        return tmp.Data;
    }

    public void Reverse()
    {
        /*
         * [F]<-[]<-[]<-[]<-[]<-[L]
         * [1]<-[2]<-[3]<-[4]<-[5]
         * [5]<-[4]<-[3]<-[2]<-[1]
         *
         * current = Last
         * prev = Last.Next
         */
        var current = Last;
        var prevLast = Last;
        QueueNode<T> prev = null;
        while (current != null)
        {
            var realNext = current.Next;
            current.Next = prev;
            prev = current;
            current = realNext;
        }

        Last = prev;
        First = prevLast;
    }

    public void Traverse()
    {
        var current = Last;
        while (current != null)
        {
            Debug.Log(current.Data);
            current = current.Next;
        }
    }

    public T Peek => Last.Data;
    public int Size => size;
}
