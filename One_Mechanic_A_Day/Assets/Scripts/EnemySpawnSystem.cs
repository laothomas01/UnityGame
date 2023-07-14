using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawnSystem : MonoBehaviour
{

    // // Start is called before the first frame update
    // [SerializeField] Camera MainCamera;
    // private float enemySpawnTimer;
    // private float enemySpawnTimeThreshold = 2f;
    // [SerializeField] private float spawnDistance = 10f; // offset
    // void Start()
    // {

    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     if (enemySpawnTimer > enemySpawnTimeThreshold)
    //     {
    //         enemySpawnTimer = 0;
    //         spawnEnemies();
    //     }
    //     else
    //     {
    //         enemySpawnTimer += Time.deltaTime;
    //     }
    // }

    // public void spawnEnemies()
    // {
    //     GameObject enemy = EnemyPool.instance.GetPooledObject();

    //     if (enemy != null)
    //     {
    //         EnemyController2D enemyController2D = enemy.GetComponent<EnemyController2D>();
            
    //         Vector3 spawnPosition = GetRandomSpawnPosition(MainCamera);
    //         spawnPosition.z = 1;
    //         enemyController2D.setPosition(spawnPosition);
    //         enemyController2D.setObjectActive(true);
    //     }
    // }
    // private Vector3 GetRandomSpawnPosition(Camera camera)
    // {
    //     Vector3 cameraPosition = camera.transform.position;
    //     Vector3 randomDirection = Random.insideUnitCircle.normalized;
    //     Vector3 spawnPosition = cameraPosition + randomDirection * spawnDistance;
    //     return spawnPosition;
    // }


}
