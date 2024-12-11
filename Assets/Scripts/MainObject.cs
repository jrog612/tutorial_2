using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public GameObject starPrefab;
    
    bool[,] quest1=new bool[5,5];
    
    // Start is called before the first frame update
    void Start()
    {
        quest1 = Quest1Check(quest1);
        //quest2 = Quest2Check(quest2);

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (quest1[i, j]) Instantiate(starPrefab, new Vector3(i*5, j*5, 0), Quaternion.identity);
                //if (quest2[i, j]) Instantiate(starPrefab, new Vector3(i*5+25, j*5+25, 0), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool[,] Quest1Check(bool[,] quest)
    {
        int count = 0;
        for(int i = 0; i<5;i++)
        {
            for (int j = count; j < 5-count; j++)
            {
                quest[i,j] = true;
            }
            count++;
        }
        return quest;
    }
    /*bool[,] Quest2Check(bool[,] quest)
    {
        int count = 0;
        for(int i = 0; i<5;i++)
        {
            for (int j = count; j < 5-count; j++)
            {
                quest[i,j] = true;
            }
            count++;
        }
        return quest;
    }*/
}