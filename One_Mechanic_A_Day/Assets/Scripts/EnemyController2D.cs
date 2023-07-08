using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Handles updates to the enemy
/// </summary>
public class EnemyController2D : MonoBehaviour
{
    
    // Start is called before the first frame update
    private float horizontal;
    private float vertical;
    private bool isFacingRight = false;
    [SerializeField] private Rigidbody2D rb;
    private GameObject player;
  
    public float maxMoveSpeed;
    private float currentMoveSpeed;
    private int canMove = 1;

  
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
       
        
    }

    // Update is called once per frame
   void Update()
   {
   

    float distance = Vector2.Distance(player.transform.position,transform.position);
    
    
    // Debug.Log("DISTANCE:" + Mathf.RoundToInt(distance));
    if (Mathf.RoundToInt(distance) == 0)
    {
        canMove = 0;
        gameObject.GetComponent<Animator>().Play("Enemy_Idle_Anim");
    }
    else
    {
        canMove = 1;
        gameObject.GetComponent<Animator>().Play("Enemy_Running_Anim");
    }

    currentMoveSpeed = maxMoveSpeed * Time.deltaTime * canMove;

    // Debug.Log("Current Move Speed: " + currentMoveSpeed);

    Flip();


// //@TODO: place into an entity manager instead
//     if(IsEnemyVisibleInCamera())
//     {
//         GetComponent<SpriteRenderer>().enabled = true;
//     }
//     else
//     {
//         GetComponent<SpriteRenderer>().enabled = false;
//     }


   }
    void FixedUpdate()
    {
    
       ChasePlayer(player);
     
    }
    private void ChasePlayer(GameObject player)
    {
   float moveDirection = Mathf.Atan2(player.transform.position.y - transform.position.y,
        player.transform.position.x - transform.position.x);
        
        horizontal = Mathf.Cos(moveDirection);
        vertical = Mathf.Sin(moveDirection);
    
        rb.velocity = new Vector2(horizontal * currentMoveSpeed, vertical * currentMoveSpeed);
    }
     private void Flip()
    {
            if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
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
