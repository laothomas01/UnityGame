using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    [SerializeField]
    static List<GameObject> enemyList;
    public static EntityManager instance;
    void Start()
    {
        enemyList = new List<GameObject>();
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {

    }
    public static List<GameObject> getEnemyList()
    {
        return enemyList;
    }
}
