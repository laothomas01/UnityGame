using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// using singleton pattern
/// </summary>
public class BulletPool : ObjectPool
{
     // Start is called before the first frame update
    public static BulletPool instance;
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
