using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlicBehavior : MeleeWeaponBehavior
{
    GarlicController gc;
    protected override void Start()
    {
        base.Start();
        gc = FindObjectOfType<GarlicController>();
    }

    void Update()
    {
        transform.position = gc.transform.position;
    }
}
