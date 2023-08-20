using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Vector3 direction;
    [SerializeField] private float moveSpeed;
    Rigidbody2D rb2D;
    public float lifeSpan;
    public float currentLifeSpan;
     bool isFacingRight = false;
    void Start()
    {
        if(this.gameObject.activeInHierarchy)
        {
            ObjectPoolManager.instance.getActiveBulletsList().Add(this.gameObject);
        }
        currentLifeSpan = lifeSpan;
        rb2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        // if (lifeSpan <= 0)
        // {
        //     lifeSpan = currentLifeSpan;
        //     this.gameObject.SetActive(false);
        // }
        lifeSpan -= Time.deltaTime;
        Move(Time.deltaTime);
        // Flip();
    }
    private void Move(float dt)
    {
        rb2D.velocity = direction * moveSpeed * dt;
        HandleMoveAnimations();

    }
    public void setDirection(float x, float y)
    {
        direction.Set(x, y, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        Collider2D[] overlappingColliders = new Collider2D[1];
        ContactFilter2D filter = new ContactFilter2D();
        filter.useTriggers = true;
        int numColliders = Physics2D.OverlapCollider(GetComponent<Collider2D>(), filter, overlappingColliders);
        for (int i = 0; i < numColliders; i++)
        {
            if (overlappingColliders[i].CompareTag("Enemy"))
            {
                // GameObject target = overlappingColliders[i].gameObject;
                // ObjectPoolManager.instance.getActiveEnemiesList().Remove(target);
                // target.SetActive(false);
                // ObjectPoolManager.instance.getActiveBulletsList().Remove(this.gameObject);
                this.gameObject.SetActive(false);
                break;
            }
        }
    }
    private void HandleMoveAnimations()
    {
        GetComponent<Animator>().Play("Fireball_Move");
    }
    //  private void Flip()
    // {
    //     if (isFacingRight && direction.x < 0 || !isFacingRight && direction.x > 0)
    //     {
    //         isFacingRight = !isFacingRight;
    //         Vector3 localScale = this.transform.localScale;
    //         localScale.x *= -1f;
    //         transform.localScale = localScale;
    //     }
    // }


}
