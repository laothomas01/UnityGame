using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Handle the front-end and back-end for targetting game objects
/// </summary>
public class TargetSystem : MonoBehaviour
{
    // Start is called before the first frame update
    // public GameObject crossHairUI;
    // public GameObject weaponUI;
    // public GameObject enemy;

    public GameObjectManager objectManager;
    public float attackRange;
    Vector3 direction;
    public float offsetDistance;
    private float rotation;
    [SerializeField] private float detectionDistanceThreshold;

    //@TODO later
    private GameObject currentTarget;
    void Start()
    {
        direction = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        // for (int i = 0; i < objectManager.GetEnemyPool().getObjectPool().Count; i++)
        // {

        //     if (objectManager.GetEnemyPool().getObjectPool()[i].activeInHierarchy)
        //     {
        //         if (Vector2.Distance(transform.position, objectManager.GetEnemyPool().getObjectPool()[i].transform.position) < detectionDistanceThreshold)
        //         {
        //             setCurrentTarget(objectManager.GetEnemyPool().getObjectPool()[i]);
        //             break;
        //         }
        //     }

        // }

    }
    public void setCurrentTarget(GameObject target)
    {
        this.currentTarget = target;
    }
    public GameObject getCurrentTarget()
    {
        return currentTarget;
    }
    public float getRotation()
    {
        return rotation;
    }
    public Vector3 getAngularOffset()
    {
        return direction;
    }
    public Vector3 getDirection()
    {
        return direction;
    }
    public float getDetectionDistance()
    {
        return detectionDistanceThreshold;
    }

    public GameObjectManager getObjectManager()
    {
        return objectManager;
    }


}
