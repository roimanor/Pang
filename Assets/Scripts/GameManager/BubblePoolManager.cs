using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblePoolManager : MonoBehaviour
{
    public static BubblePoolManager Instance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;
    [SerializeField] private Transform bubblesParent;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool, transform);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    /// <summary>
    /// I have decided to use object pooling, in case we want to create a level with many bubbles.
    /// right now it is not really necessary.
    /// </summary>
    /// <returns>returns an unused bubble</returns>

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    /// <summary>
    /// returns all bubbles to the pool
    /// </summary>
    public void ReleaseAll()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            pooledObjects[i].SetActive(false);
        }
    }
}
