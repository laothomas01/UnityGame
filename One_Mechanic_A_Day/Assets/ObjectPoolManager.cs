using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ObjectPoolManager : MonoBehaviour
{

   public static ObjectPoolManager instance;
   private List<GameObject> bulletPool = new List<GameObject>();

   private List<GameObject> enemyPool = new List<GameObject>();

   public int amountToPool;

   [SerializeField] private GameObject bulletPrefab;

   private void Awake()
   {
      if (instance == null) { instance = this; }
   }

   void Start()
   {
      initializeBulletPool(amountToPool);
   }
   void Update()
   {

   }
   public void initializeBulletPool(float amountToPool)
   {
      for (int i = 0; i < amountToPool; i++)
      {
         GameObject obj = Instantiate(bulletPrefab);
         obj.SetActive(false);
         bulletPool.Add(obj);
      }
   }
   public GameObject GetPooledBulletObject()
   {
      for (int i = 0; i < bulletPool.Count; i++)
      {
         if (!bulletPool[i].activeInHierarchy)
         {
            return bulletPool[i];
         }
      }
      return null;
   }
}
