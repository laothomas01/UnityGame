using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// handle basic player attributes, user input and other player related features 
/// </summary>
public class Player : MonoBehaviour
{
    private float horizontalDirection;
    private float verticalDirection;
    Vector3 direction;
    [SerializeField] private float moveSpeed;
    Rigidbody2D rb2D;
    bool isFacingRight = false;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move(Time.deltaTime);
        Flip();
    }
    private void Move(float dt)
    {
        horizontalDirection = Input.GetAxisRaw("Horizontal");
        verticalDirection = Input.GetAxisRaw("Vertical");
        direction.Set(horizontalDirection, verticalDirection, 0);
        rb2D.velocity = direction * moveSpeed * dt;
        HandleMoveAnimations();
    }
    private void Flip()
    {
        if (isFacingRight && horizontalDirection < 0 || !isFacingRight && horizontalDirection > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = this.transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    private void HandleMoveAnimations()
    {
        if (horizontalDirection != 0 || verticalDirection != 0)
        {
            GetComponent<Animator>().Play("Run_Anim");
        }
        else
        {
            GetComponent<Animator>().Play("Idle_Anim");

        }
    }
}
