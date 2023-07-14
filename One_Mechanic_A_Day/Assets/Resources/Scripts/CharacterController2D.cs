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


   //calculate direction between player and enemy
   // TargetSystem targetSystem;
   private float testAttackTimer = 0f;
   public float testAttackTimeThreshold = 3f;
   private TargetSystem targetSystem;
   void Start()
   {
      targetSystem = GetComponent<TargetSystem>();
      rb = gameObject.GetComponent<Rigidbody2D>();
   }
   // Update is called once per frame
   void Update()
   {

      if (testAttackTimer > testAttackTimeThreshold)
      {
         testAttackTimer = 0;
         Attack();
      }
      else
      {
         testAttackTimer += Time.deltaTime;
      }
      direction.Set(moveHorizontal,moveVertical,0);
      HandleUserInput();
      HandleMoveAnimations();
      Flip();

   }

   private void HandleUserInput()
   {
      moveHorizontal = Input.GetAxisRaw("Horizontal");
      moveVertical = Input.GetAxisRaw("Vertical");
   }

   private void Attack()
   {


      GameObject bullet = ObjectPoolManager.instance.GetPooledBulletObject();

      if (bullet != null && targetSystem.getCurrentTarget() != null)
      {
         bullet.SetActive(true);
         Vector3 direction = targetSystem.getCurrentTarget().transform.position - this.transform.position;
         float rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
         bullet.transform.position = this.transform.position; // iniitial_position + direction * offset distance
         bullet.transform.rotation = Quaternion.Euler(0, 0, rotation);
         direction.Normalize();
         bullet.GetComponent<BulletController2D>().setDirection(direction);

      }

   }
   private void HandleMoveAnimations()
   {
      if (rb.velocity.x != 0 || rb.velocity.y != 0)
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
