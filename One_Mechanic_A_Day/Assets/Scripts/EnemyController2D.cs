using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController2D : MonoBehaviour
{

    enum enemyState
    {
        moving,
        idle
    }

    //movement direction 
    private float horizontal;
    private float vertical;
    //flipping horizontal transform
    private bool isFacingRight = false;
    //physics component
    [SerializeField] private Rigidbody2D rb;

    //target to follow
    private GameObject player;

    public float maxMoveSpeed;

    enemyState state;

    Vector3 direction;

    bool isDead_;
     void Awake()
    {
        isDead_ = false;
        TargetSystem.GetEnemyList().Add(this.gameObject);
        maxMoveSpeed = UnityEngine.Random.Range(50, 150);
        state = enemyState.moving;


    }

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
    
        //==================== handle enemy movement state ================================
        float distanceBetweenPlayer = Vector2.Distance(player.transform.position, transform.position);

        if (Mathf.RoundToInt(distanceBetweenPlayer) == 0)
        {
            state = enemyState.idle;
        }
        else
        {
            state = enemyState.moving;
        }

        if (state == enemyState.idle)
        {
            direction.Set(0, 0, 0);
            gameObject.GetComponent<Animator>().Play("Enemy_Idle_Anim");
        }
        else
        {
            ChasePlayer(player);
        }
        //=======================================================================================
        

        //will this cause problems? 
        if(isDead_)
        {
            TargetSystem.GetEnemyList().Remove(this.gameObject);
            setObjectActive(false);
        }
        rb.velocity = direction * maxMoveSpeed * Time.deltaTime;

        Flip();
    }
    void FixedUpdate()
    {
        // ChasePlayer(player);
    }
    private void ChasePlayer(GameObject player)
    {

        float moveDirection = Mathf.Atan2(player.transform.position.y - transform.position.y,
             player.transform.position.x - transform.position.x);

        horizontal = Mathf.Cos(moveDirection);
        vertical = Mathf.Sin(moveDirection);

        direction.Set(horizontal, vertical, 0);

        gameObject.GetComponent<Animator>().Play("Enemy_Running_Anim");

    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    public void setPosition(Vector3 position)
    {
        transform.position = position;
    }
    public void setObjectActive(bool active)
    {
        this.gameObject.SetActive(active);
    }

    public void setIsDead(bool dead)
    {
        isDead_ = dead;
    }
    public bool isDead()
    {
        return isDead_;
    }

}
