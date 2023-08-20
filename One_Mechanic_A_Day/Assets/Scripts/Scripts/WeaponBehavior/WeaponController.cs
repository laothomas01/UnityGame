using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basic script for all weapon controllers
/// </summary>
public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]

    public WeaponScriptableObject weaponData;
    // public GameObject prefab;   
    // public float damage;
    // public float speed;
    // public float cooldownDuration;
    // public int pierce;
    float currentCooldown;


    protected PlayerMovement pm;

    protected virtual void Start()
    {

        // currentCooldown = cooldownDuration;
        pm = FindAnyObjectByType<PlayerMovement>();
        currentCooldown = weaponData.CooldownDuration;

    }

    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0f)
        {
            Attack();
        }
    }
    protected virtual void Attack()
    {
        currentCooldown = weaponData.CooldownDuration;
    }
}
