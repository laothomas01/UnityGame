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

    //    private float moveHorizontal;
    //    private float moveVertical;
    //    [SerializeField] private float moveSpeed = 1f;
    //    private bool isFacingRight = false;
    //    [SerializeField] private Rigidbody2D rb;
    //    Vector3 direction;

    //    [SerializeField] private float testAttackTimer = 0f;
    //    public float testAttackTimeThreshold;
    //    private TargetSystem targetSystem;
    //    public bool DEBUG;
    //    public GameObject testBulletPrefab;
    //    void Start()
    //    {
    //       targetSystem = GetComponent<TargetSystem>();
    //       rb = gameObject.GetComponent<Rigidbody2D>();
    //    }
    //    void Update()
    //    {
    //       // Attack();
    //       HandleUserInput();
    //       HandleMoveAnimations();
    //       Flip();

    //    }

    //    private void HandleUserInput()
    //    {
    //       moveHorizontal = Input.GetAxisRaw("Horizontal");
    //       moveVertical = Input.GetAxisRaw("Vertical");
    //       direction.Set(moveHorizontal, moveVertical, 0);
    //       direction.Normalize();
    //    }


    // //@TODO instead of using an actual projectile to hit enemies, use a ray cast and put an animation over it. 
    //    private void Attack()
    //    {

    //       //note: we will use instantiation instead for now
    //       GameObject bullet = ObjectPoolManager.instance.GetPooledBulletObject();
    //       if (testAttackTimer > testAttackTimeThreshold)
    //       {
    //          testAttackTimer = 0;
    //          if (bullet != null && targetSystem.getClosestEnemy() != null)
    //          {
    //             // Debug.Log("Shoot");  
    //             BulletController2D bulletController2D = bullet.GetComponent<BulletController2D>();
    //             bulletController2D.setPosition(this.transform.position);
    //             Vector3 direction = targetSystem.getClosestEnemy().transform.position - this.transform.position;
    //             direction.Normalize();
    //             bulletController2D.setDirection(direction);
    //             float rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
    //             bulletController2D.setRotation(0, 0, rotation);
    //             bullet.SetActive(true);
    //          }
    //       }


    //       testAttackTimer += Time.deltaTime;


    //    }
    //    private void HandleMoveAnimations()
    //    {
    //       if (moveHorizontal != 0 || moveVertical != 0)
    //       {
    //          gameObject.GetComponent<Animator>().Play("Run_Anim");
    //       }
    //       else
    //       {
    //          gameObject.GetComponent<Animator>().Play("Idle_Anim");
    //       }
    //    }
    //    //handle movement physics
    //    private void FixedUpdate()
    //    {

    //       rb.velocity = direction * moveSpeed * Time.deltaTime;
    //    }


    //    //flip game object based on movement direction
    //    //
    //    private void Flip()
    //    {
    //       if (isFacingRight && moveHorizontal < 0f || !isFacingRight && moveHorizontal > 0f)
    //       {
    //          isFacingRight = !isFacingRight;
    //          Vector3 localScale = transform.localScale;
    //          localScale.x *= -1f;
    //          transform.localScale = localScale;
    //       }
    //    }
    //    private bool IsAttackOnCooldown()
    //    {
    //       if (testAttackTimer < testAttackTimeThreshold)
    //       {
    //          return true;
    //       }
    //       return false;
    //    }

}
