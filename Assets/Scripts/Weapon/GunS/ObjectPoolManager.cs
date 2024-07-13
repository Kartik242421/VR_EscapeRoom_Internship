using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager Instance;

    public GameObject shootingParticlePrefab;  // Prefab for shooting particle
    public int poolSize = 10;                  // Initial size of the object pool

    private List<GameObject> pool;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        pool = new List<GameObject>();
        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(shootingParticlePrefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                return pool[i];
            }
        }

        GameObject newObj = Instantiate(shootingParticlePrefab);
        newObj.SetActive(false);
        pool.Add(newObj);
        return newObj;
    }
}
