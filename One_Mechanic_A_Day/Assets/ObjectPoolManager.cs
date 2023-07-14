using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ObjectPoolManager : MonoBehaviour
{

   public static ObjectPoolManager instance;
   private List<GameObject> bulletPool = new List<GameObject>();

   private List<GameObject> enemyPool = new List<GameObject>();

   public int bulletAmountToPool;
   public int enemyAmountToPool;


   [SerializeField] private GameObject bulletPrefab;
   [SerializeField] private GameObject enemyPrefab;

   private void Awake()
   {
      if (instance == null) { instance = this; }
   }

   void Start()
   {
      initializeBulletPool(bulletAmountToPool);
      initializeEnemyPool(enemyAmountToPool);
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
   public List<GameObject> getBulletPool()
   {
      return bulletPool;
   }
   public GameObject GetPooledEnemyObject()
   {
       for (int i = 0; i < enemyPool.Count; i++)
      {
         if (!enemyPool[i].activeInHierarchy)
         {
            return enemyPool[i];
         }
      }
      return null;
   }
   public void initializeEnemyPool(float amountToPool)
   {
      for (int i = 0; i < amountToPool; i++)
      {
         GameObject obj = Instantiate(enemyPrefab);
         obj.SetActive(false);
         enemyPool.Add(obj);
      }
   }

    public List<GameObject> getEnemyPool()
   {
      return enemyPool;
   }
}
