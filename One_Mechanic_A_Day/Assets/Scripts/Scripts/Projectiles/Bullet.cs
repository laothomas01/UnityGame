using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    [SerializeField] Vector3 direction;
    public float moveSpeed;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Move(Time.deltaTime);
    }
    private void Move(float dt)
    {
        direction.Normalize();
        rigidbody2D.velocity = direction * moveSpeed * dt;
    }
    public void setDirection( Vector3 dir)
    {
        direction = dir;
    }


}
