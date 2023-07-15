using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Handle the front-end and back-end for targetting game objects
/// </summary>
public class TargetSystem : MonoBehaviour
{
    public float detectionRange_;
    private float waitToDetectClosestEnemyTimer_;
    public float waitToDetectClosestEnemyTimeout_;
    GameObject closestEnemy_;
    void Start()
    {
        closestEnemy_ = null;
    }
    void Update()
    {

        findClosestEnemy();
        handleDoneWaitingToDetectClosestEnemyEvent();

    }
    public void findClosestEnemy()
    {

        //no close enemy detected
        if (closestEnemy_ == null)
        {
            // loop through pool of spawned enemies and detect the nearest enemy
            foreach (GameObject enemy in ObjectPoolManager.instance.getEnemyPool())
            {
                float distanceBetween_ = Vector3.Distance(this.transform.position, enemy.transform.position);
                if (distanceBetween_ <= detectionRange_)
                {
                    // Debug.Log("Found closest enemy:" + enemy);
                    setClosestEnemy(enemy);
                    break;
                }
            }
        }


        // already spotted a nearby enemy
        if (closestEnemy_ != null)
        {
            float distanceBetween_ = Vector3.Distance(closestEnemy_.transform.position, this.gameObject.transform.position);
            Debug.Log("Distance between player and enemy: " + distanceBetween_);

            // make sure current closest enemy is in range
            if (distanceBetween_ > detectionRange_)
            {
                startWaitToDetectClosestEnemyTimer();
            }
            else
            {
                //if player is in range, just reset the timer
                cancelWaitToDetectClosestEnemyTimer();
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
    public void setClosestEnemy(GameObject close_)
    {
        closestEnemy_ = close_;
    }
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
