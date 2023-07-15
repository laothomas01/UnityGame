using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// - handle player movement
/// - handle player attacking
/// - 
/// </summary>
public class CharacterController2D : MonoBehaviour
{

   private float moveHorizontal;
   private float moveVertical;
   [SerializeField] private float moveSpeed = 1f;
   private bool isFacingRight = false;
   [SerializeField] private Rigidbody2D rb;
   Vector3 direction;

   private float testAttackTimer = 0f;
   public float testAttackTimeThreshold;
   private TargetSystem targetSystem;
   public bool DEBUG;
   void Start()
   {
      targetSystem = GetComponent<TargetSystem>();
      rb = gameObject.GetComponent<Rigidbody2D>();
      DEBUG = true;
   }
   void Update()
   {

      HandleUserInput();
      HandleMoveAnimations();
      Flip();

      // section to debug /visualize business logic 
      if (DEBUG)
      {
         if (targetSystem.getClosestEnemy() != null)
         {
            Debug.DrawLine(transform.position, targetSystem.getClosestEnemy().transform.position, Color.green);
         }
      }

      // testAttackTimer += Time.deltaTime;

   }

   private void HandleUserInput()
   {
      moveHorizontal = Input.GetAxisRaw("Horizontal");
      moveVertical = Input.GetAxisRaw("Vertical");
      direction.Set(moveHorizontal, moveVertical, 0);
   }

   private void Attack()
   {
      GameObject bullet = ObjectPoolManager.instance.GetPooledBulletObject();


      if (bullet != null)
      {
         Vector3 direction;
         if (targetSystem.getClosestEnemy() != null)
         {
            bullet.SetActive(true);
            bullet.transform.position = this.transform.position;
            direction = targetSystem.getClosestEnemy().transform.position - this.transform.position;
            float rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            bullet.GetComponent<BulletController2D>().setDirection(direction);
            bullet.GetComponent<BulletController2D>().setPosition(this.transform.position);
            bullet.GetComponent<BulletController2D>().setRotation(0, 0, rotation);
         }

      }

   }
   private void HandleMoveAnimations()
   {
      if (moveHorizontal != 0 || moveVertical != 0)
      {
         gameObject.GetComponent<Animator>().Play("Run_Anim");
      }
      else
      {
         gameObject.GetComponent<Animator>().Play("Idle_Anim");
      }
   }
   //handle movement physics
   private void FixedUpdate()
   {

      rb.velocity = direction * moveSpeed * Time.deltaTime;
   }


   //flip game object based on movement direction
   //
   private void Flip()
   {
      if (isFacingRight && moveHorizontal < 0f || !isFacingRight && moveHorizontal > 0f)
      {
         isFacingRight = !isFacingRight;
         Vector3 localScale = transform.localScale;
         localScale.x *= -1f;
         transform.localScale = localScale;
      }
   }
   private bool IsAttackOnCooldown()
   {
      if (testAttackTimer < testAttackTimeThreshold)
      {
         return true;
      }
      return false;
   }

}
