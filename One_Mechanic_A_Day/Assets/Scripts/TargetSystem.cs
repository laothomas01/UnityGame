using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Handle the front-end and back-end for targetting game objects
/// </summary>
public class TargetSystem : MonoBehaviour
{
    public float detectionRange_;
    [SerializeField] private float waitToDetectClosestEnemyTimer_;
    public float waitToDetectClosestEnemyTimeout_;
    GameObject closestEnemy_;
    public static List<GameObject> enemyList = new List<GameObject>();

    public static List<GameObject> GetEnemyList()
    {
        return enemyList;
    }
    void Start()
    {
        closestEnemy_ = null;
    }
    void Update()
    {

        findClosestEnemy();

        //@TODO place into an event queue instead
        handleDoneWaitingToDetectClosestEnemyEvent();

        //choosing next closest enemy


        if (closestEnemy_ != null)
        {
            if (closestEnemy_.GetComponent<EnemyController2D>().isDead())
            {
                setClosestEnemy(null);
            }
            Debug.DrawLine(this.transform.position, closestEnemy_.transform.position, Color.green);
        }

    }
    public void findClosestEnemy()
    {
        //if closest enemy not found or is dead, search for next
        if (closestEnemy_ == null)
        {
            foreach (GameObject enemy in enemyList)
            {
                if (Vector3.Distance(transform.position, enemy.transform.position) < detectionRange_)
                {
                    //Enemy within range
                    setClosestEnemy(enemy);
                    break;
                }
            }

        }
        //if closest enemy found and not dead, check current closest enemy's distance
        if (closestEnemy_ != null)
        {
            //calculate distance between player and current closest enemy
            if (Vector3.Distance(transform.position, closestEnemy_.transform.position) < detectionRange_)
            {
                cancelWaitToDetectClosestEnemyTimer();
            }
            else
            {
                startWaitToDetectClosestEnemyTimer();
            }
        }

        // foreach (GameObject enemy in ObjectPoolManager.instance.getEnemyPool())
        // {
        //     if (!enemy.activeInHierarchy)
        //     {
        //         continue;
        //     }
        //     else
        //     {
        //         if (Vector3.Distance(transform.position, enemy.transform.position) < detectionRange_)
        //         {
        //             setClosestEnemy(enemy);
        //         }
        //     }
        // }
        // //no close enemy detected
        // if (closestEnemy_ == null)
        // {
        //     // loop through pool of spawned enemies and detect the nearest enemy
        //     foreach (GameObject enemy in ObjectPoolManager.instance.getEnemyPool())
        //     {
        //         float distanceBetween_ = Vector3.Distance(this.transform.position, enemy.transform.position);
        //         if (distanceBetween_ <= detectionRange_)
        //         {
        //             // Debug.Log("Found closest enemy:" + enemy);
        //             setClosestEnemy(enemy);
        //             break;
        //         }
        //     }
        // }


        // // already spotted a nearby enemy
        // if (closestEnemy_ != null)
        // {
        //     float distanceBetween_ = Vector3.Distance(closestEnemy_.transform.position, this.gameObject.transform.position);
        //     // Debug.Log("Distance between player and enemy: " + distanceBetween_);

        //     // make sure current closest enemy is in range
        //     if (distanceBetween_ > detectionRange_)
        //     {
        //         startWaitToDetectClosestEnemyTimer();
        //     }
        //     else
        //     {
        //         //if player is in range, just reset the timer
        //         cancelWaitToDetectClosestEnemyTimer();
        //     }
        // }

        // handleDoneWaitingToDetectClosestEnemyEvent();


    }

    public void startWaitToDetectClosestEnemyTimer()
    {
        // Debug.Log("Detected! " + closestEnemy_);
        waitToDetectClosestEnemyTimer_ += Time.deltaTime;
    }
    public void cancelWaitToDetectClosestEnemyTimer()
    {
        waitToDetectClosestEnemyTimer_ = 0;
        // Debug.Log("Wait Timer Reset: " + waitToDetectClosestEnemyTimer_);

    }
    public void setClosestEnemy(GameObject closest_)
    {
        closestEnemy_ = closest_;
    }

    //@TODO add to event queue and handle from there
    public void handleDoneWaitingToDetectClosestEnemyEvent()
    {
        if (waitToDetectClosestEnemyTimer_ > waitToDetectClosestEnemyTimeout_)
        {
            setClosestEnemy(null);
        }
    }
    public GameObject getClosestEnemy()
    {
        return closestEnemy_;
    }
}
