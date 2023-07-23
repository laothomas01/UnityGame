using UnityEngine;

/// <summary>
/// do i want to make this class applicable to all other entities that can attack???? 
// current state: player searches through list of enemies and finds closest one
//  
/// </summary>
public class TargettingSystem : MonoBehaviour
{
    public float detectRange = 0;
    public GameObject GetNearestTarget()
    {

        foreach (GameObject enemy in ObjectPoolManager.instance.getActiveEnemiesList())
        {
            
            if (enemy.activeInHierarchy)
            {
                float distance = Vector3.Distance(enemy.transform.position, this.transform.position);
                // Debug.Log("enemy active:" + enemy.name + "distance:" + distance);
                if (distance < detectRange)
                {
                    // Debug.Log("Found target!");
                    return enemy;
                }
            }
        }
        return null;
        
    }
}
