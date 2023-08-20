using UnityEngine;

public abstract class BaseEntity
{
    public abstract float moveSpeed { get; }
    public abstract Vector3 moveDirection { get; }
    public abstract bool isFacingRight { get; }

    public abstract void Move(float dt);
    public abstract void Flip();

    public abstract void Stop();

}