using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class BulletController2D : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private float bulletSpeed;
    private Vector3 direction;
    // Start is called before the first frame update

    public float animationDuration = 2f;
    private float lifeSpan;
    public float lifeSpanThreshold;

    //handling overlapping collider detection

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (lifeSpan > lifeSpanThreshold)
        {
            lifeSpan = 0;
            this.gameObject.SetActive(false);
        }
        else
        {
            lifeSpan += Time.deltaTime;
        }
        rb.velocity = direction * bulletSpeed * Time.deltaTime;

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            //useful for handling explosions or corpse explosion
            Collider2D[] overlappingColliders = new Collider2D[1];
            ContactFilter2D filter = new ContactFilter2D();
            filter.useTriggers = true;
            int numColliders = Physics2D.OverlapCollider(GetComponent<Collider2D>(), filter, overlappingColliders);
            for (int i = 0; i < numColliders; i++)
            {
                if (overlappingColliders[i].CompareTag("Enemy"))
                {
                    // Handle the collision with the enemy

                    // Deactivate the enemy

                    overlappingColliders[i].gameObject.SetActive(false);

                    setObjectActive(false);

                    // Break out of the loop after deactivating the first enemy hit
                    break;
                }
            }
        }

    }

    public Rigidbody2D GetRigidbody2D()
    {
        return rb;
    }
    public float getBulletSpeed()
    {
        return bulletSpeed;
    }
    public void setSpeed(float s)
    {
        bulletSpeed = s;
    }
    public void setDirection(float x, float y)
    {
        direction = new Vector3(x, y);
    }
    public Vector2 getDirection()
    {
        return direction;
    }
    public void setObjectActive(bool active)
    {
        this.gameObject.SetActive(active);
    }
    public void setPosition(float x, float y)
    {
        transform.position = new Vector3(x, y);
    }
    public void setPosition(Vector3 newPos)
    {
        transform.position = newPos;
    }
    public void setDirection(Vector3 dir)
    {
        direction = dir;
    }
    public void move(float dt)
    {
        rb.velocity = getDirection() * bulletSpeed * dt;
    }
    public void setRotation(float xrot, float yrot, float zrot)
    {
        transform.rotation = Quaternion.Euler(xrot, yrot, zrot);
    }


}
