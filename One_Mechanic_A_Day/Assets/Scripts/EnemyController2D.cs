using UnityEngine;

public class EnemyController2D : MonoBehaviour
{

    // [SerializeField] Vector3 direction;
    // [SerializeField] private float moveSpeed;
    // private float horizontal;
    // private float vertical;
    // Rigidbody2D rb2D;
    // bool isFacingRight = false;
    // private GameObject player;
    // void Awake()
    // {
    //     ObjectPoolManager.instance.getActiveEnemiesList().Add(this.gameObject);
    //     Debug.Log(ObjectPoolManager.instance.getActiveEnemiesList().Count);
    // }
    // void Start()
    // {

    //     player = GameObject.Find("Player");
    //     rb2D = GetComponent<Rigidbody2D>();
    //     ObjectPoolManager.instance.getActiveEnemiesList().Add(this.gameObject);
    //     Debug.Log(ObjectPoolManager.instance.getActiveEnemiesList().Count);
    // }
    // void Update()
    // {
    //     HandleMovementBehavior();
    //     HandleMoveAnimations();
    //     Move(Time.deltaTime);
    //     Flip();
    // }
    // private void ChasePlayer(GameObject player)
    // {

    //     float moveDirection = Mathf.Atan2(player.transform.position.y - transform.position.y,
    //     player.transform.position.x - transform.position.x);

    //     horizontal = Mathf.Cos(moveDirection);
    //     vertical = Mathf.Sin(moveDirection);

    //     direction.Set(horizontal, vertical, 0);
    // }
    // private void HandleMovementBehavior()
    // {
    //     float distanceBetweenPlayer = Vector2.Distance(player.transform.position, transform.position);
    //     if (Mathf.RoundToInt(distanceBetweenPlayer) == 0)
    //     {
    //         Stop();
    //     }
    //     else
    //     {
    //         ChasePlayer(player);

    //     }

    // }
    // private void Move(float dt)
    // {
    //     rb2D.velocity = direction * moveSpeed * dt;
    // }
    // private void Stop()
    // {
    //     direction.Set(0, 0, 0);

    // }

    // private void HandleMoveAnimations()
    // {
    //     if (direction.x != 0 || direction.y != 0)
    //     {

    //         gameObject.GetComponent<Animator>().Play("Enemy_Running_Anim");

    //     }
    //     else
    //     {
    //         gameObject.GetComponent<Animator>().Play("Enemy_Idle_Anim");

    //     }
    // }
    // private void Flip()
    // {
    //     if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
    //     {
    //         isFacingRight = !isFacingRight;
    //         Vector3 localScale = transform.localScale;
    //         localScale.x *= -1f;
    //         transform.localScale = localScale;
    //     }
    // }

}
