using UnityEngine;

public class TargettingSystem : MonoBehaviour
{
    GameObject currentTarget = null;
    public float detectRange = 0;
    public float chooseNextTargetTime = 0;
    public float chooseNextTargetDeadline;

    void Update()
    {
        //if current target not found, find target
        if (currentTarget == null)
        {
            findTarget();
        }

        //if target found
        else
        {
            //calculate distance between current target and player
            float distance = Vector3.Distance(this.transform.position, currentTarget.transform.position);

            //if target found, cancel timer
            if (distance < detectRange)
            {
                cancelChooseNextTargetTimer();
            }
            else
            {
                startChooseNextTargetTimer(Time.deltaTime);
            }
            Debug.DrawLine(this.transform.position, currentTarget.transform.position, Color.green);
            handleChooseNextTargetEvent();


        }


    }
    void setCurrentTarget(GameObject target)
    {
        currentTarget = target;
    }
    public GameObject getCurrentTarget()
    {
        return currentTarget;
    }
    void findTarget()
    {
        foreach (GameObject enemy in EntityManager.getEnemyList())
        {
            float distance = Vector3.Distance(this.transform.position, enemy.transform.position);
            if (distance < detectRange)
            {
                setCurrentTarget(enemy);
                break;
            }
        }
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
