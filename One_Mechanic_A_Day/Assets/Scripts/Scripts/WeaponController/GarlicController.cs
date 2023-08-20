using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlicController : WeaponController
{
    // Start is called before the first frame update
    protected virtual void Start()
    {
        base.Start();
    }
    protected override void Attack()
    {
        base.Attack();
        GameObject spawnGarlic = Instantiate(weaponData.Prefab);
        spawnGarlic.transform.position = transform.position;
    } 

}
