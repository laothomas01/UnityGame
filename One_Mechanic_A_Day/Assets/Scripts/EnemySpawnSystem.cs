using UnityEngine;


public class EnemySpawnSystem : MonoBehaviour
{
    [SerializeField]
    private float timeToSpawn;
    private float timeSinceSpawn;

    private static float spawnDistance = 10f;

    public static EnemySpawnSystem instance;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Update()
    {

        timeSinceSpawn += Time.deltaTime;
        if (timeSinceSpawn >= timeToSpawn)
        {
            ObjectPoolManager.instance.GetEnemy();
            timeSinceSpawn = 0f;
            Debug.Log(ObjectPoolManager.instance.getActiveEnemiesList().Count);

        }
    }


    public Vector3 spawnAroundCamera()
    {
        Camera camera = Camera.main;
        Vector3 cameraPosition = camera.transform.position;
        Vector3 randomDirection = Random.insideUnitCircle.normalized;
        Vector3 spawnPosition = cameraPosition + randomDirection * spawnDistance;
        spawnPosition.z = 1;
        return spawnPosition;
    }


}
