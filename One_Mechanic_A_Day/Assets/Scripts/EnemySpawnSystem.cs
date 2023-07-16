using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Video;

public class EnemySpawnSystem : MonoBehaviour
{
    [SerializeField] Camera MainCamera;
    [SerializeField] private float enemySpawnTimer;
    [SerializeField] private float enemySpawnTimeThreshold = 2f;
    private float spawnDistance = 10f;

    void Update()
    {
        if (enemySpawnTimer > enemySpawnTimeThreshold)
        {
            enemySpawnTimer = 0;
            spawnEnemies();
        }
        else
        {
            enemySpawnTimer += Time.deltaTime;
        }
    }

    private void spawnEnemies()
    {

        GameObject enemy = ObjectPoolManager.instance.GetPooledEnemyObject();
        EnemyController2D enemyController2D = enemy.GetComponent<EnemyController2D>();
        enemyController2D.setObjectActive(true);
        // if (enemy != null)
        // {
        Vector3 spawnPosition = GetRandomSpawnPosition(MainCamera);
        enemyController2D.setPosition(spawnPosition);
        // }
        // else
        // {

        // }

        Debug.Log(enemy.active);

    }

    private Vector3 GetRandomSpawnPosition(Camera camera)
    {
        Vector3 cameraPosition = camera.transform.position;
        Vector3 randomDirection = Random.insideUnitCircle.normalized;
        Vector3 spawnPosition = cameraPosition + randomDirection * spawnDistance;
        spawnPosition.z = 1;
        return spawnPosition;
    }


}
