using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    // public float moveSpeed;
    EnemyStats enemy;

    void Start()
    {
        enemy = GetComponent<EnemyStats>();
        player = FindObjectOfType<PlayerMovement>().transform;
    }
    void Update()
    {
        Move(Time.deltaTime);
    }
    void FixedUpdate()
    {

    }
    void Move(float dt)
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, enemy.currentMoveSpeed * dt);
    }
}
