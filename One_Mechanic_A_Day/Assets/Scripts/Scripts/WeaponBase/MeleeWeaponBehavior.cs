using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Base script of all melee behaviors [To be placed on a prefab of a weapon that is melee]
/// </summary>
public class MeleeWeaponBehavior : MonoBehaviour
{
    public WeaponScriptableObject weaponData;
    public float destroyAfterSeconds;
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    void Update()
    {

    }
}
