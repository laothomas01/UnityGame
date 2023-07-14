using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Handle the front-end and back-end for targetting game objects
/// </summary>
public class TargetSystem : MonoBehaviour
{
    private GameObject currentTarget = null;
    public GameObject testEnemyPrefab;
    void Start()
    {
            // for testing
            setCurrentTarget(testEnemyPrefab);
    }
    void Update()
    {

    }
    public void setCurrentTarget(GameObject target)
    {
        currentTarget = target;
    }

    public GameObject getCurrentTarget()
    {
        return currentTarget;
    }


}
