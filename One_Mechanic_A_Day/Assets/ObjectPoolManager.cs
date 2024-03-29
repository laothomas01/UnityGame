using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// improvements: 
//    - as game gets larger, going to need more pools
///   - can use 
/// </summary>
public class ObjectPoolManager : MonoBehaviour
{
   [SerializeField]
   private GameObject enemyPrefab;
   [SerializeField]
   private List<GameObject> enemyPool = new List<GameObject>();
   private List<GameObject> activeEnemies = new List<GameObject>();

   [SerializeField]
   private GameObject bulletPrefab;
   private List<GameObject> bulletPool = new List<GameObject>();
   private List<GameObject> activeBullets = new List<GameObject>();
   public int enemyPoolStartSize;
   public int bulletPoolStartSize;
   public static ObjectPoolManager instance;
   private void Start()
   {
      if (instance == null)
      {
         instance = this;
      }
      initializeEnemyPool(enemyPoolStartSize);
      initializeBulletPool(bulletPoolStartSize);

   }
   void Update()
   {
   }
   //load enemy pool with fixed amount of enemy objects
   public void initializeEnemyPool(float amount)
   {
      for (int i = 0; i < amount; i++)
      {
         GameObject enemy = Instantiate(enemyPrefab);
         enemyPool.Add(enemy);
         enemy.SetActive(false);
      }
   }

   //retrieve object from enemy pool
   public GameObject GetEnemy()
   {
      if (enemyPool.Count > 0)
      {
         //retrieve first element from pool
         GameObject enemy = enemyPool[0];
         //remove first element from pool after retrieval
         enemy.SetActive(true);
         //when enemy is enabled, also enable its controller script
         enemyPool.Remove(enemy);
         return enemy;
      }
      return null;
   }

   public List<GameObject> getActiveEnemiesList()
   {
      return activeEnemies;
   }

   //puts enemy object back to pool
   public void ReturnEnemy(GameObject enemy)
   {
      enemyPool.Add(enemy);
      enemy.SetActive(false);
   }

   public void initializeBulletPool(float amount)
   {
      for (int i = 0; i < amount; i++)
      {
         GameObject bullet = Instantiate(bulletPrefab);
         bulletPool.Add(bullet);
         bullet.SetActive(false);
      }
   }

   public GameObject GetBullet()
   {
      if (bulletPool.Count > 0)
      {
         //retrieve first bullet element from pool
         GameObject bullet = bulletPool[0];
         //remove first bullet element from pool after retrieval
         bullet.SetActive(true);
         //when bullet is enabled, also enable its controller script
         bulletPool.Remove(bullet);
         return bullet;
      }
      return null;
   }
   public List<GameObject> getActiveBulletsList()
   {
      return activeBullets;
   }

   //puts bullet object back to pool
   public void ReturnBullet(GameObject bullet)
   {
      bulletPool.Add(bullet);
      bullet.SetActive(false);
   }

}
