using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController2D : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private float bulletSpeed;
    private Vector3 direction;
    // Start is called before the first frame update
  
     public float animationDuration = 2f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    
    }

    // Update is called once per frame
    void Update()
    {
        //@TODO make sure to select the proper animation to the respective bullet
        // gameObject.GetComponent<Animator>().Play("Fireball_Move");
    }
    void FixedUpdate()
    {
         move(Time.fixedDeltaTime);
    }
   

   //@TODO find a way to trigger an explosion animation
    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.CompareTag("Enemy"))
        {
            setObjectActive(false);
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
        direction = new Vector3(x,y);
    }
    public Vector2 getDirection()
    {
        return direction;
    }
    public void setObjectActive(bool active)
    {
        this.gameObject.SetActive(active);
    }
    public void setPosition(float x,float y)
    {
        transform.position = new Vector3(x,y);
    }
    public void setPosition(Vector3 newPos)
    {
        transform.position = newPos;
    }
    public void setDirection(Vector3 dir)
    {
        direction = dir;
    }
    public void move( float dt)
    {
        rb.velocity = new Vector2(getDirection().x,getDirection().y) * bulletSpeed * dt;
    }
    public void setRotation(float rotation)
    {
        transform.rotation = Quaternion.Euler(0,0,rotation);
    }


}
