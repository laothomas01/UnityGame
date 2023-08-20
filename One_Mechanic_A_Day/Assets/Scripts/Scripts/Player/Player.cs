

using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D rb;
    public float moveSpeed = 5f;
    bool isFacingRight = false;
    private float vertical;
    private float horizontal;
    Vector2 moveDir;
    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        rb = GetComponent<Rigidbody2D>();
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
        float moveX = Input.GetAxis("Horizontal");
        float moveY =  Input.GetAxis("Vertical");
        moveDir = new Vector2(moveX,moveY).normalized;
    }
    void Move()
    {
        //should i use moveSpeed * Time.FixedDeltaTime?
        rb.velocity = new Vector2(moveDir.x * moveSpeed,moveDir.y * moveSpeed);
    }

    // public override float moveSpeed => 10;

    // public override Vector3 moveDirection => new Vector3();

    // public override bool isFacingRight => false;

    // void Start()
    // {

    // }

    // // private float horizontalMove;
    // // private float verticalMove;
    // // private bool isFacingRight = false;
    // // private Vector3 moveDirection;
    // // public float moveSpeed;
    // // Rigidbody2D rigidbody2D;

    // // void Start()
    // // {
    // //     rigidbody2D = GetComponent<Rigidbody2D>();
    // // }
    // // void Update()
    // // {
    // //     Flip();

    // // }
    // // void FixedUpdate()
    // // {
    // //     Move(Time.fixedDeltaTime);
    // // }
    // // private void Flip()
    // // {
    // //     if (isFacingRight && moveDirection.x < 0 || !isFacingRight && moveDirection.x > 0)
    // //     {
    // //         isFacingRight = !isFacingRight;
    // //         Vector3 localScale = this.transform.localScale;
    // //         localScale.x *= -1f;
    // //         transform.localScale = localScale;
    // //     }
    // // }

    // // public void Move(float dt)
    // // {

    // //     horizontalMove = Input.GetAxis("Horizontal");
    // //     verticalMove = Input.GetAxis("Vertical");
    // //     moveDirection.Set(horizontalMove, verticalMove, 0);
    // //     rigidbody2D.velocity = moveDirection * moveSpeed * dt;
    // // }
    // public override void Flip()
    // {
    //     throw new System.NotImplementedException();
    // }

    // public override void Move(float dt)
    // {
    //     throw new System.NotImplementedException();
    // }

    // public override void Stop()
    // {
    //     throw new System.NotImplementedException();
    // }
}
