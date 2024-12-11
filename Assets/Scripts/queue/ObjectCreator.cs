using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectCreator : MonoBehaviour
{
    public GameObject prefab;
    public int CreateCount;

    public int poolSize = 10;

    public List<GameObject> objList = new();
    public Queue<GameObject> objPool = new();

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            objPool.Enqueue(obj);
        }
    }

    GameObject GetPooledObject()
    {
        if (objPool.Count > 0)
        {
            GameObject obj = objPool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject obj = Instantiate(prefab);
                obj.SetActive(false);
                objPool.Enqueue(obj);
            }

            return objPool.Dequeue();
        }
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        objPool.Enqueue(obj);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < CreateCount; i++)
            {
                float x = Random.Range(-100, 100);
                float y = Random.Range(-100, 100);
                float z = Random.Range(-100, 100);

                var go = GetPooledObject();
                go.transform.position = new Vector3(x, y, z);
                objList.Add(go);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Delete))
        {
            for (var i = 0; i < objList.Count; i++)
            {
                ReturnToPool(objList[i]);
            }

            objList.Clear();
        }
    }
}