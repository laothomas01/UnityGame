using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Handle the front-end and back-end for targetting game objects
/// </summary>
public class TargetSystem : MonoBehaviour
{
    public float detectionRange;
    // public float detectionRangeThreshold = 10f;
    // public float enemyOutOfRangeThreshold = 5f;
    // private float enemyDetectionTimer;
    // private bool isEnemyInRange;

    // public GameObject objectPoolManager;

    // EnemyPool enemyPool;
    // BulletPool bulletPool;

    // private GameObject currentTargetEnemy;
    // void Start()
    // {
    //     enemyPool = objectPoolManager.GetComponent<EnemyPool>();
    //     bulletPool = objectPoolManager.GetComponent<BulletPool>();
    //     isEnemyInRange = false;
    // }

    // // Update is called once per frame
    // void Update()
    // {


    //     // Loop through the enemy pool

    //     // foreach(GameObject enemy in enemyPool)

    //     // foreach (GameObject enemy in enemyPool.getObjectPool())
    //     // {
    //     //     if (!enemy.activeInHierarchy)
    //     //     {
    //     //         continue;
    //     //     }

    //     //     //Calculate distance between player and enemy

    //     //     float distance = Vector3.Distance(transform.position, enemy.transform.position);

    //     //     if (distance < detectionRangeThreshold)
    //     //     {
    //     //         if (currentTargetEnemy == null || distance < Vector3.Distance(transform.position, currentTargetEnemy.transform.position))
    //     //         {
    //     //             currentTargetEnemy = enemy;
    //     //             break;
    //     //         }
    //     //     }
    //     // }

    //     // //check if current enemy is in range
    //     // if (currentTargetEnemy != null)
    //     // {
    //     //     float distance = Vector3.Distance(transform.position, currentTargetEnemy.transform.position);
    //     //     if (distance < detectionRangeThreshold)
    //     //     {
    //     //         // Reset enemy detection timer
    //     //         enemyDetectionTimer = 0f;
    //     //         isEnemyInRange = true;
    //     //     }
    //     // }
    //     // else
    //     // {
    //     //     // Increment enemy detection timer
    //     //     enemyDetectionTimer += Time.deltaTime;

    //     //     // Check if enemy is out of range for too long

    //     //     if (enemyDetectionTimer > enemyOutOfRangeThreshold)
    //     //     {
    //     //         // // Find next closest enemy
    //     //         currentTargetEnemy = GetNextClosestEnemy();
    //     //         enemyDetectionTimer = 0f;
    //     //     }
    //     // }
    //     // //Create fireball towwards current target enemy
    // }

    // private GameObject GetNextClosestEnemy()
    // {
    //     GameObject nextClosestEnemy = null;
    //     float closestDistance = Mathf.Infinity;

    //     foreach (GameObject enemy in enemyPool.getObjectPool())
    //     {

    //         // Exclude the current target enemy OR enemy not active in hierarchy
    //         if (enemy == currentTargetEnemy || !enemy.activeInHierarchy)
    //             continue;

    //         float distance = Vector3.Distance(transform.position, enemy.transform.position);

    //         if (distance < closestDistance)
    //         {
    //             closestDistance = distance;
    //             nextClosestEnemy = enemy;
    //         }
    //     }

    //     return nextClosestEnemy;
    // }
    
    // // public void setCurrentTarget(GameObject target)
    // // {
    // //     this.currentTarget = target;
    // // }
    // public GameObject getCurrentTarget()
    // {
    //     return currentTargetEnemy;
    // }
    // public float getDetectionDistance()
    // {
    //     return detectionRangeThreshold;
    // }
    // public void setDetectionTimer(float time)
    // {
    //     enemyDetectionTimer = time;
    // }
    // public void setIsEnemyInRange(bool inrange)
    // {
    //     isEnemyInRange = inrange;
    // }
   


}
