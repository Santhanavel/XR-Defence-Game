using UnityEngine;
using System.Collections.Generic;

public class ObjectPoolManager : MonoBehaviour
{
    [SerializeField] private List<ObjectPool> objectsToPool;

    // Pool Dictionary
    public Dictionary<string, Queue<GameObject>> poolDictionary
        = new Dictionary<string, Queue<GameObject>>();

    private void Start()
    {
        poolDictionary.Clear();
        StartPool();
    }
    private void StartPool()
    {
        foreach (ObjectPool pool in objectsToPool)
        {
            Queue<GameObject> objectQueue = new Queue<GameObject>();

            for (int i = 0; i < pool.poolCount; i++)
            {
                GameObject obj = Instantiate(pool.obj);
                obj.SetActive(false);
                objectQueue.Enqueue(obj);
            }

            poolDictionary.Add(pool.Name, objectQueue);
        }
    }

    // Get object from pool
    public GameObject GetFromPool(string poolName)
    {
        if (!poolDictionary.ContainsKey(poolName))
        {
            Debug.LogWarning("Pool not found: " + poolName);
            return null;
        }

        GameObject obj = poolDictionary[poolName].Dequeue();
        obj.SetActive(true);
        poolDictionary[poolName].Enqueue(obj);

        return obj;
    }
}

[System.Serializable]
public class ObjectPool
{
    public string Name;
    public GameObject obj;
    [Range(1, 150)]
    public int poolCount = 25;
}