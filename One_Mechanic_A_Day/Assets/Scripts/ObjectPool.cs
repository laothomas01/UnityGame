using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class ObjectPool : MonoBehaviour
{

   // private List<GameObject> pooledObjects = new List<GameObject>();

   // [SerializeField] protected int amountToPool;
   // [SerializeField] protected GameObject prefab;

   // protected void initPool(float amount)
   // {
   //    for(int i = 0; i < amountToPool; i++)
   //    {
   //       GameObject gameObject = Instantiate(prefab);
   //       gameObject.SetActive(false);
   //       pooledObjects.Add(gameObject);
   //    }
   // }
   // public GameObject GetPooledObject()
   // {
   //    for(int i = 0; i < pooledObjects.Count; i++)
   //    {
   //       if(!pooledObjects[i].activeInHierarchy)
   //       {
   //          pooledObjects[i].SetActive(true);
   //          return pooledObjects[i];
   //       }
   //    }
   //    return null;
   // }
   // public List<GameObject> getObjectPool()
   // {
   //    return pooledObjects;
   // }



}
