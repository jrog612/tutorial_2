using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListExample : MonoBehaviour
{
    void Start()
    {
        DLinkedList<int> list0 = new DLinkedList<int>();
        DLinkedList<int> list2 = new DLinkedList<int>();
        DLinkedList<int> list3 = new DLinkedList<int>();
        DLinkedList<int> list4 = new DLinkedList<int>();
        
        list0.AddFirst(3);
        list0.AddFirst(2);
        list0.AddFirst(1);
        list0.AddFirst(0);

        foreach (DNode<int> item in list0)
        {
            Debug.Log(item.Data);
        }
        
        // Debug.Log("케이스 1----------");
        // list1.Traverse();
        //
        // Debug.Log("케이스 2----------");
        // list2.AddLast(0);
        // list2.AddLast(1);
        // list2.AddLast(2);
        // list2.AddLast(3);
        // list2.Traverse();
        //
        // Debug.Log("케이스 3----------");
        // list3.AddFirst(1);
        // list3.AddLast(2);
        // list3.AddFirst(0);
        // list3.AddLast(3);
        // list3.Traverse();
        //
        // Debug.Log("케이스 4----------");
        // list4.AddLast(2);
        // list4.AddFirst(1);
        // list4.AddFirst(0);
        // list4.AddLast(3);
        // list4.Traverse();
    }

    // Update is called once per frame
    void Update()
    {
    }
}




