using UnityEngine;

public class TargettingSystem : MonoBehaviour
{
    GameObject currentTarget = null;
    public float detectRange = 0;
    public float chooseNextTargetTime = 0;
    public float chooseNextTargetDeadline;

    void Update()
    {
        // //if current target not found, find target
        // if (currentTarget == null)
        // {
        //     findNearestTarget();

        // }
        // if(getNearestTarget() != null)
        // {
        //             Debug.DrawLine(this.transform.position,getNearestTarget().transform.position,Color.green);
        // }
        // else
        // {
        //     //make sure target is still being detected
        //     float distance = Vector3.Distance(currentTarget.transform.position, this.transform.position);
        //     Debug.Log("current target: " + currentTarget.GetHashCode() + "distance:" + distance);
        //     if (distance < detectRange)
        //     {
        //         Debug.Log("Current target out of range!");
        //     }
        //     // if (distance < detectRange)
        //     // {
        //     //     currentTarget = null;
        //     // }
        //     // else
        //     // {
        //     //     Debug.DrawLine(this.transform.position, currentTarget.transform.position, Color.green);
        //     // }

        // }

        // //if target found
        // else
        // {
        //     //calculate distance between current target and player
        //     float distance = Vector3.Distance(this.transform.position, currentTarget.transform.position);

        //     //if target found, cancel timer
        //     if (distance < detectRange)
        //     {
        //         cancelChooseNextTargetTimer();
        //         setCurrentTarget(currentTarget);
        //     }
        //     else
        //     {
        //         startChooseNextTargetTimer(Time.deltaTime);
        //     }
        //     Debug.DrawLine(this.transform.position, currentTarget.transform.position, Color.green);
        //     handleChooseNextTargetEvent();


        // }


    }
    void setCurrentTarget(GameObject target)
    {
        currentTarget = target;
    }
    public GameObject getCurrentTarget()
    {
        return currentTarget;
    }
    public GameObject getNearestTarget()
    {
        // foreach (GameObject enemy in EntityManager.getEnemyList())
        // {
        //     float distance = Vector3.Distance(this.transform.position, enemy.transform.position);
        //     if (distance < detectRange)
        //     {
        //         setCurrentTarget(enemy);
        //         break;
        //     }
        // }
        // foreach(GameObject enemy in ObjectPoolManager.instance.GetEnemyPool())
        // {
        //     if(enemy.activeInHierarchy)
        //     {
        //         float distance = Vector3.Distance(enemy.transform.position,this.transform.position);
        //         Debug.Log("enemy active:" + enemy.name + "distance:" + distance);
        //         // if(distance < detectRange)
        //         // {
        //         //     Debug.Log("Nearest enemy:" + enemy.name + " Distance: " + distance);
        //         // }
        //     }
        //     // else
        //     // {
        //     //     Debug.Log(enemy.name + "inactive");
        //     // }
        //     // if(enemy!= null && enemy.activeInHierarchy)
        //     // {
        //     //     float distance = Vector3.Distance(this.transform.position,enemy.transform.position);
        //     //     if(distance < detectRange)
        //     //     {
        //     //         currentTarget = enemy;
        //     //         break;
        //     //     }
        //     // }
        // }

        foreach (GameObject enemy in ObjectPoolManager.instance.getActiveEnemiesList())
        {
            if (enemy.activeInHierarchy)
            {
                float distance = Vector3.Distance(enemy.transform.position, this.transform.position);
                // Debug.Log("enemy active:" + enemy.name + "distance:" + distance);
                if (distance < detectRange)
                {
                    Debug.Log("Found target!");
                    return enemy;
                }
            }
        }
        return null;
    }
    void startChooseNextTargetTimer(float dt)
    {
        chooseNextTargetTime += dt;
    }
    void cancelChooseNextTargetTimer()
    {
        chooseNextTargetTime = 0;
    }
    public void handleChooseNextTargetEvent()
    {
        if (chooseNextTargetTime > chooseNextTargetDeadline)
        {
            setCurrentTarget(null);
        }
    }
}
