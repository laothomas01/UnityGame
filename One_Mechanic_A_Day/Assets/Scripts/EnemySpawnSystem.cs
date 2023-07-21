using UnityEngine;

public class EnemySpawnSystem : MonoBehaviour
{
    [SerializeField] Camera MainCamera;
    [SerializeField] private float enemySpawnTimer;
    [SerializeField] private float maxEnemySpawnCooldown;
    private float spawnDistance = 10f;
    GameObject enemy;
    void Update()
    {



        if (enemySpawnTimer > maxEnemySpawnCooldown)
        {
            enemySpawnTimer = 0;

            enemy = ObjectPoolManager.instance.GetPooledEnemyObject();
            enemy.transform.position = spawnAroundCamera(MainCamera);
            EntityManager.getEnemyList().Add(enemy);
            enemy.SetActive(true);
        }
        else

        {
            enemySpawnTimer += Time.deltaTime;

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
