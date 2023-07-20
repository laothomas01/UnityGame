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
    TargettingSystem targetSystem;
    public GameObject testBulletPrefab;

    public float maxAttackCooldown;
    private float currentAttackCooldown;
    void Start()
    {
        currentAttackCooldown = maxAttackCooldown;
        rb2D = GetComponent<Rigidbody2D>();
        targetSystem = GetComponent<TargettingSystem>();
    }

    void Update()
    {
        // // will be testing basic projectile launching
        if (maxAttackCooldown < 0)
        {
            // if(targetSystem.getCurrentTarget() != null)
            // {
            //     Attack(targetSystem.getCurrentTarget());
            //     // Debug.Log("Attack");
            // }
            maxAttackCooldown = currentAttackCooldown;

            Attack(targetSystem.getCurrentTarget());
        }
        else
        {
            maxAttackCooldown -= Time.deltaTime;
        }


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
    public void Attack(GameObject target)
    {
        if (target != null)
        {
            testBulletPrefab.transform.position = this.transform.position;
            float moveDirectionAngle = Mathf.Atan2(target.transform.position.y - this.transform.position.y,
            target.transform.position.x - this.transform.position.x);
            testBulletPrefab.GetComponent<Bullet>().setDirection(new Vector3(Mathf.Cos(moveDirectionAngle),Mathf.Sin(moveDirectionAngle),0));
            Instantiate(testBulletPrefab);
        }
        // testBulletPrefab.transform.position = this.transform.position;

        // Instantiate(testBulletPrefab);
    }


}
