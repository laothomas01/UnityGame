using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Video;

public class EnemySpawnSystem : MonoBehaviour
{
    [SerializeField] Camera MainCamera;
    [SerializeField] private float enemySpawnTimer;
    [SerializeField] private float maxEnemySpawnCooldown;
    private float spawnDistance = 10f;
    [SerializeField] private GameObject enemyPrefab;

    void Update()
    {

        enemySpawnTimer += Time.deltaTime;
        if (enemySpawnTimer >= maxEnemySpawnCooldown)
        {
            enemyPrefab.transform.position = spawnAroundCamera(MainCamera);
            GameObject enemy = Instantiate(enemyPrefab);

            //each enemy spawn, add the spawned enemy to a list
            EntityManager.getEnemyList().Add(enemy);
            enemySpawnTimer = 0;
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
