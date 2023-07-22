using UnityEngine;



public class EnemySpawnSystem : MonoBehaviour
{
    [SerializeField] Camera MainCamera;
    [SerializeField]
    private float timeToSpawn;
    private float timeSinceSpawn;

    private float spawnDistance = 10f;
    GameObject enemy;
    void Update()
    {

        timeSinceSpawn += Time.deltaTime;
        if (timeSinceSpawn >= timeToSpawn)
        {
            GameObject newEnemy = ObjectPoolManager.instance.GetEnemy();
            if(newEnemy != null)
            {
                 newEnemy.transform.position = spawnAroundCamera(MainCamera);
            }
            //reset spawn timer
            timeSinceSpawn = 0f;
        }
    }

    private Vector3 spawnAroundCamera(Camera camera)
    {
        Vector3 cameraPosition = camera.transform.position;
        Vector3 randomDirection = Random.insideUnitCircle.normalized;
        Vector3 spawnPosition = cameraPosition + randomDirection * spawnDistance;
        spawnPosition.z = 1;
        return spawnPosition;
    }


}
