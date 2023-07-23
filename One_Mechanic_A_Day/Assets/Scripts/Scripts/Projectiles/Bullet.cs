using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Vector3 direction;
    [SerializeField] private float moveSpeed;
    private float horizontal;
    private float vertical;
    Rigidbody2D rb2D;
    public float lifeSpan;
    public float currentLifeSpan;
    void Awake()
    {
        ObjectPoolManager.instance.getActiveBulletsList().Add(this.gameObject);
        // Debug.Log(ObjectPoolManager.instance.getActiveBulletsList().Count);
    }
    void Start()
    {
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
        // lifeSpan -= Time.deltaTime;
        Move(Time.deltaTime);
    }
    private void Move(float dt)
    {
        rb2D.velocity = direction * moveSpeed * dt;
    }
    public void setDirection(float x, float y)
    {
        direction.Set(x, y, 0);
    }
    public void setDirection(Vector3 direction)
    {
        direction.Set(direction.x, direction.y, direction.z);
    }


}
