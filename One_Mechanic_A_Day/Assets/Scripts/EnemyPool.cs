using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    // Start is called before the first frame update
    public static EnemyPool instance;
    private List<GameObject> pooledObjects = new List<GameObject>();
    [SerializeField] private int amountToPool = 20;
    [SerializeField] private GameObject enemyPrefab;
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        for(int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(enemyPrefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }
     public GameObject GetPooledObject()
    {
        for(int i= 0; i < pooledObjects.Count; i++)
        {
            //if we find an available bullet that we can shoot
           if(!pooledObjects[i].activeInHierarchy)
           {
                return pooledObjects[i];
           } 
        
        }
        return null;
    }

    public List<GameObject> getObjectPool()
    {
        return pooledObjects;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
