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

    private float horizontal;
    private float vertical;
    private bool isFacingRight = false;
    [SerializeField] private Rigidbody2D rb;

    //target to follow
    private GameObject player;

    public float maxMoveSpeed;
    enemyState state;

    Vector3 direction;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        maxMoveSpeed = Random.Range(90, 200);
        state = enemyState.moving;
    }

    // Update is called once per frame
    void Update()
    {
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

        direction.Set(horizontal,vertical,0);

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




}
