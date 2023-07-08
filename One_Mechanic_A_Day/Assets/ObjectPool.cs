using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
     public static ObjectPool instance;
    private List<GameObject> pooledObjects = new List<GameObject>();
    public int bulletPoolAmount;
    public int enemyPoolAmount;
    
    //@TODO do not limit yourself to the fireball prefab
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject enemyPrefab;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update

    void Start()
    {
        //instantiate pool with amount wanted to pool
        for(int i = 0; i < bulletPoolAmount; i++)
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
        for(int i = 0; i < enemyPoolAmount; i++)
        {
               GameObject obj = Instantiate(bulletPrefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }
    public GameObject GetBulletPooledObject()
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
