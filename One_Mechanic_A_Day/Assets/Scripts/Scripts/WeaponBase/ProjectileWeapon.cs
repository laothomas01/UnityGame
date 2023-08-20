using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Base script of all projectile behaviors [To be placed on a prefab of a weapon that is a projectile]
/// </summary>
// rename to "ProjectileWeaponBehavior"

public class ProjectileWeapon : MonoBehaviour
{
    public WeaponScriptableObject weaponData;
    protected Vector3 direction; 
    public float destroyAfterSeconds;
    //Current stats
    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected int currentPierce;
    void Awake()
    {
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CooldownDuration;
        currentPierce = weaponData.Pierce;
    }
    public float GetCurrentDamage()
    {
        return currentDamage *= FindObjectOfType<PlayerStats>().currentMight;
    }
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    void Update()
    {

    }

    public void DirectionChecker(Vector3 dir)
    {
        // Debug.Log("Direction Check!");
        // Debug.Log("Before:" + direction);
        direction = dir;
        // Debug.Log("After:" + direction);
        float dirx = direction.x;
        float diry = direction.y;

        Vector3 scale = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;

        if (dirx < 0 && diry == 0) //left
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            // Debug.Log("LEft");
        }
        else if (dirx == 0 && diry < 0) // down
        {
            scale.y *= -1;
        }
        else if (dirx == 0 && diry > 0) // up
        {
            scale.x = scale.x * -1;
        }

        else if (dir.x > 0 && dir.y > 0) // right up 
        {
            rotation.z = 0f;
        }
        else if (dir.x > 0 && dir.y < 0) //right down
        {
            rotation.z = -90f;
        }
        else if (dir.x < 0 && dir.y > 0) //left up
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z = -90f;
        }
        else if (dir.x < 0 && dir.y < 0) // left down
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z = 0f;
        }
        transform.localScale = scale;
        transform.rotation = Quaternion.Euler(rotation); // Can't simply set the vector because cannot convert to vector3
    }
    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Enemy"))
        {
            // Debug.Log(col.name);
            EnemyStats enemy = col.GetComponent<EnemyStats>();
            enemy.TakeDamage(GetCurrentDamage()); //Make sure to use currentDamage instead of weaponData.damage in case any multipliers are used in the future
        }
    }
    
}
