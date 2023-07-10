using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// using singleton pattern
/// </summary>
public class BulletPool : MonoBehaviour
{
    public static BulletPool instance;
    private List<GameObject> pooledObjects = new List<GameObject>();
    public int amountToPool = 20;
    
    //@TODO do not limit yourself to the fireball prefab
    [SerializeField] private GameObject bulletPrefab;
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
        for(int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(bulletPrefab);
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
