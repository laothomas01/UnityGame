using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    [SerializeField]
    static List<GameObject> enemyList;
    static List<GameObject> bulletList;
    public static EntityManager instance;
    void Start()
    {
        enemyList = new List<GameObject>();
        if (instance == null)
        {
            instance = this;
        }
    }

    public static List<GameObject> getEnemyList()
    {
        return enemyList;
    }
    public static List<GameObject> getBulletList()
    {
        return bulletList;
    }
}
