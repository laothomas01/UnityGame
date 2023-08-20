using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //References 
    Rigidbody2D rb;
    // public PlayerScriptableObjects player;
    //Movement
    public float moveSpeed = 5f;
    bool isFacingRight = false;
    public Vector2 moveDir;
    [HideInInspector]
    public Vector2 lastMovedVector;
    PlayerStats player;
    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        rb = GetComponent<Rigidbody2D>();
        lastMovedVector = new Vector2(1,0f); //if we dont do this and game starts up, and the player doesnt move, the projectile will have no momentum
        player = GetComponent<PlayerStats>();
    }

    // Frame rate dependent
    void Update()
    {
        InputManagement();
    }
    // Frame rate independent
    void FixedUpdate()
    {
        Move();
    }
    void InputManagement()
    {
        float lastHorizontalVector = Input.GetAxis("Horizontal");
        float lastVerticalVector = Input.GetAxis("Vertical");
        moveDir = new Vector2(lastHorizontalVector, lastVerticalVector).normalized;
        if (moveDir.x != 0)
        {
            lastHorizontalVector = moveDir.x;
            lastMovedVector = new Vector2(lastHorizontalVector, 0f); // last moved x
        }
        if (moveDir.y != 0)
        {
            lastVerticalVector = moveDir.y;
            lastMovedVector = new Vector2(0f,lastVerticalVector); //last moved y
        }
        if(moveDir.x != 0 && moveDir.y != 0)
        {
            lastMovedVector= new Vector2(lastHorizontalVector,lastVerticalVector); //while moving diagonally 
        }

    }
    void Move()
    {
        //should i use moveSpeed * Time.FixedDeltaTime?
        rb.velocity = new Vector2(moveDir.x * player.currentMoveSpeed, moveDir.y * player.currentMoveSpeed);
    }
}
