using UnityEngine;


public class EnemyReturn : MonoBehaviour
{

    // callback function that performs a behavior when class is disabled
    private void OnDisable()
    {
        if (ObjectPoolManager.instance != null)
        {
            ObjectPoolManager.instance.ReturnEnemy(this.gameObject);
        }
    }
}
