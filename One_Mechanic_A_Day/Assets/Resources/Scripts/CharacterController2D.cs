using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handle updates to the player
/// </summary>
public class CharacterController2D : MonoBehaviour
{
   
   private float moveHorizontal;
   private float moveVertical;
   [SerializeField] private float moveSpeed = 1f;
   private bool isFacingRight = false;
   [SerializeField] private Rigidbody2D rb;
   
   //calculate direction between player and enemy
   TargetSystem targetSystem;
   private float testAttackTimer;
   private float testAttackTimeThreshold = 3f;
   
    void Start()
    {
           targetSystem = GetComponent<TargetSystem>();
           rb = gameObject.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
         if(testAttackTimer > testAttackTimeThreshold)
         {
            testAttackTimer = 0;
            Attack();
         }
         else
         {
            testAttackTimer += Time.deltaTime;
         }
     
       HandleUserInput();
       HandleMoveAnimations();
       Flip();
       testAttackTimer += Time.deltaTime;
       
    }
    
   private void HandleUserInput()
   {
           moveHorizontal = Input.GetAxisRaw("Horizontal");
           moveVertical = Input.GetAxisRaw("Vertical");
   }
   
   private void Attack()
   {

      //@TODO retrofit this into a skill manager
         GameObject bullet = BulletPool.instance.GetPooledObject();
         if(bullet != null)
         {

         BulletController2D bulletController2D = bullet.GetComponent<BulletController2D>();
         bulletController2D.setPosition(transform.position);
         Vector3 direction = targetSystem.enemy.transform.position - transform.position;
         bulletController2D.setDirection(direction);
         float rotation = Mathf.Atan2(-direction.y,-direction.x) * Mathf.Rad2Deg;
         bulletController2D.setRotation(rotation);
         bulletController2D.setObjectActive(true);
         }
      

   }

    private void HandleMoveAnimations()
    {
           if(rb.velocity.x != 0 || rb.velocity.y != 0)
           {
              gameObject.GetComponent<Animator>().Play("Run_Anim");    
           } 
           else
           {
              gameObject.GetComponent<Animator>().Play("Idle_Anim");   
           }
    }
    //handle movement physics
    private void FixedUpdate() {

             rb.velocity = new Vector2(moveHorizontal * moveSpeed * Time.deltaTime,moveVertical * moveSpeed * Time.fixedDeltaTime);    
    }

    
    //flip game object based on movement direction
    //
    private void Flip()
    {
            if(isFacingRight && moveHorizontal < 0f || !isFacingRight && moveHorizontal > 0f)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
    }
    
}
