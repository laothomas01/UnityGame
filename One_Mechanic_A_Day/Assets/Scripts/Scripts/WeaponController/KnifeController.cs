using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : WeaponController
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnKnife = Instantiate(weaponData.Prefab);
        // Debug.Log(spawnKnife);
        spawnKnife.transform.position = transform.position; // Assign the position to be the same as this object which is parented to the player
        spawnKnife.GetComponent<KnifeBehavior>().DirectionChecker(pm.lastMovedVector);
    }


}
