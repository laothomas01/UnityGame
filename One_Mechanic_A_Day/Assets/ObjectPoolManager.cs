using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// - Singleton pattern used???
/// </summary>
public class ObjectPoolManager : MonoBehaviour
{
   // [SerializeField]
   // private GameObject enemyPrefab;
   // [SerializeField]

   // //create the pool for resusable objects
   // private Queue<GameObject> enemyPool = new Queue<GameObject>();
   // [SerializeField]
   // private int poolStartSize = 5;

   // public static ObjectPoolManager instance;
   // private void Start()
   // {
   //    if (instance == null)
   //    {
   //       instance = this;
   //    }
   //    initializeEnemyPool(poolStartSize);
   // }
   // public void initializeEnemyPool(float n)
   // {
   //    for (int i = 0; i < n; i++)
   //    {
   //       GameObject enemy = Instantiate(enemyPrefab);
   //       enemyPool.Enqueue(enemy);
   //       enemy.SetActive(false);
   //    }
   // }


   // public GameObject GetEnemy()
   // {

   //    //if pool already populated
   //    if (enemyPool.Count > 0)
   //    {
   //       //use first object in queue
   //       GameObject enemy = enemyPool.Dequeue();
   //       enemy.SetActive(true);
   //       return enemy;
   //    }
   //    else
   //    {
   //       //populate queue for first time
   //       GameObject enemy = Instantiate(enemyPrefab);
   //       return enemy;
   //    }

   // }
   
   // public void ReturnEnemy(GameObject enemy)
   // {
   //    enemyPool.Enqueue(enemy);
   //    enemy.SetActive(false);
   // }

   // private void OnDisable()
   // {
   //    if()
   // }





   // public static ObjectPoolManager instance;
   // private List<GameObject> bulletPool = new List<GameObject>();

   // private List<GameObject> enemyPool = new List<GameObject>();

   // public int bulletAmountToPool;
   // public int enemyAmountToPool;


   // [SerializeField] private GameObject bulletPrefab;
   // [SerializeField] private GameObject enemyPrefab;

   // private void Awake()
   // {
   //    if (instance == null) { instance = this; }
   // }

   // void Start()
   // {
   //    initializeBulletPool(bulletAmountToPool);
   //    initializeEnemyPool(enemyAmountToPool);
   // }
   // void Update()
   // {

   // }
   // public void initializeBulletPool(float amountToPool)
   // {
   //    for (int i = 0; i < amountToPool; i++)
   //    {
   //       GameObject obj = Instantiate(bulletPrefab);
   //       obj.SetActive(false);
   //       bulletPool.Add(obj);
   //    }
   // }
   // public GameObject GetPooledBulletObject()
   // {
   //    for (int i = 0; i < bulletPool.Count; i++)
   //    {
   //       if (!bulletPool[i].activeInHierarchy)
   //       {
   //          return bulletPool[i];
   //       }
   //    }
   //    return null;
   // }
   // public List<GameObject> getBulletPool()
   // {
   //    return bulletPool;
   // }
   // public GameObject GetPooledEnemyObject()
   // {
   //     for (int i = 0; i < enemyPool.Count; i++)
   //    {
   //       if (!enemyPool[i].activeInHierarchy)
   //       {
   //          return enemyPool[i];
   //       }
   //    }
   //    return null;
   // }
   // public void initializeEnemyPool(float amountToPool)
   // {
   //    for (int i = 0; i < amountToPool; i++)
   //    {
   //       GameObject obj = Instantiate(enemyPrefab);
   //       obj.SetActive(false);
   //       enemyPool.Add(obj);
   //    }
   // }

   //  public List<GameObject> getEnemyPool()
   // {
   //    return enemyPool;
   // }
}
