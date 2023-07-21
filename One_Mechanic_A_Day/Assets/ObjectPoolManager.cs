using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
   public GameObject bulletPrefab;
   public GameObject enemyPrefab;
   public static List<GameObject> bulletPool = new List<GameObject>();
   public static List<GameObject> enemyPool = new List<GameObject>();
   public static ObjectPoolManager instance;
   public float bulletPoolAmount;
   public float enemyPoolAmount;

   GameObject bulletToPool;
   GameObject enemyToPool;

   public void Start()
   {
      if (instance == null)
      {
         instance = this;
      }
      initializeBulletPool(bulletPoolAmount);
      initializeEnemyPool(enemyPoolAmount);

   }

   public void initializeBulletPool(float poolAmount)
   {
      for (int i = 0; i < poolAmount; i++)
      {
         bulletToPool = Instantiate(bulletPrefab);
         bulletToPool.SetActive(false);
         bulletPool.Add(bulletToPool);
      }
   }

   public void initializeEnemyPool(float poolAmount)
   {
      for (int i = 0; i < poolAmount; i++)
      {
         enemyToPool = Instantiate(enemyPrefab);
         enemyToPool.SetActive(false);
         enemyPool.Add(enemyToPool);
      }
   }

   public GameObject GetPooledBulletObject()
   {
      for (int i = 0; i < bulletPoolAmount; i++)
      {
         if (!bulletPool[i].activeInHierarchy)
         {
            return bulletPool[i];
         }
      }
      return null;
   }

   public GameObject GetPooledEnemyObject()
   {
      for (int i = 0; i < enemyPoolAmount; i++)
      {
         GameObject enemy = enemyPool[i];
         if (!enemy.activeInHierarchy)
         {
            return enemyPool[i];
         }
      }
      return null;
   }
}
