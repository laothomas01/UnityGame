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
    public static List<GameObject> projectiles = new List<GameObject>();


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
            else
            {
                Debug.DrawLine(this.transform.position, closestEnemy_.transform.position, Color.green);

            }
        }

    }
    public void findClosestEnemy()
    {
        //if closest enemy not found or is dead, search for next
        if (closestEnemy_ == null)
        {
            for (int i = 0; i < TargetSystem.GetEnemyList().Count; i++)
            {
                GameObject enemy = TargetSystem.GetEnemyList()[i];
                if (enemy != null)
                {
                    if (Vector3.Distance(transform.position, enemy.transform.position) < detectionRange_)
                    {
                        //Enemy within range
                        setClosestEnemy(enemy);
                        break;
                    }
                }
            }

        }
        if(closestEnemy_ != null)
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

    public static List<GameObject> GetEnemyList()
    {
        return enemyList;
    }
    public static List<GameObject> GetProjectileList()
    {
        return projectiles;
    }
}
