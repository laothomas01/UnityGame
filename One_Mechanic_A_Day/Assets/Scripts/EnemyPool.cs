using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : ObjectPool
{
    // Start is called before the first frame update
    public static EnemyPool instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
            // initPool(amountToPool);
    }
}
