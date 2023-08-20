using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemyScriptableObject enemyData;


    //Current stats
    [HideInInspector]
    public float currentMoveSpeed;
    [SerializeField]
    public float currentHealth;
    [HideInInspector]
    public float currentDamage;
    public bool isDead;

    public float despawnDistance = 20f;
    Transform player;
    private void Awake()
    {
        player = FindObjectOfType<PlayerStats>().transform;
        currentMoveSpeed = enemyData.MoveSpeed;
        currentDamage = enemyData.Damage;
        currentHealth = enemyData.MaxHealth;
    }

    public void TakeDamage(float dmg)
    {
        Debug.Log(currentHealth);

        currentHealth -= dmg;

        if (currentHealth <= 0)
        {
            Kill();
        }

    }
    void Update()
    {
        if (outOfPlayerRange())
        {
            ReturnEnemy();
        }
    }
    public void Kill()
    {

        Destroy(gameObject);
    }
    void onDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            return;
        }
        EnemySpawner es = FindObjectOfType<EnemySpawner>();
        es.OnEnemyKilled();
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            PlayerStats player = col.gameObject.GetComponent<PlayerStats>();
            player.TakeDamage(currentDamage); // make sure to use current damage instead of weaponData.damage incase damage multipliers will be used                
        }
    }

    bool outOfPlayerRange()
    {
        if (Vector2.Distance(transform.position, player.position) >= despawnDistance)
        {
            return true;
        }
        return false;
    }

    //respawn current enemy to a new position around the player
    void ReturnEnemy()
    {
        transform.position = new Vector2(player.position.x + Random.Range(-10, 10), player.position.y + Random.Range(-10, 10));
    }

}

