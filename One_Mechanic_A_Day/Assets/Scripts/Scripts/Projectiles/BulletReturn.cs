using UnityEngine;

public class BulletReturn : MonoBehaviour
{
     // callback function that performs a behavior when class is disabled
    private void OnDisable()
    {
        if (ObjectPoolManager.instance != null)
        {
            ObjectPoolManager.instance.ReturnBullet(this.gameObject);
        }
    }
}
