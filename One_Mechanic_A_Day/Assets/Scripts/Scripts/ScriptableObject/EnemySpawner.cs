using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// by using a wave count, you are not spawning enemies every few seconds at a time
/// you spawn the necessary amount, then wave for a time interval to timeout
/// then spawn the next group of enemies
/// 
/// 
/// i feel like a new wave should occur every minute
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class EnemyGroup
    {
        public string enemyName;
        public int enemyCount; // number of enemies to spawn in this wave
        public int spawnCount; // number of enemies of this type already spawned in this wave
        public GameObject enemyPrefab;
    }

    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public List<EnemyGroup> enemyGroups; // list of grups of enemies in this wave 
        public int waveQuota; // total number of enemies to spawn this wave
        public float spawnInterval; // interval at which to spawn enemies
        public int spawnCount; // number of enemies already spawned in this wave
    }


    Transform player;


    public List<Wave> waves; // list of waves in this game
    public int currentWaveCount;  //the index of the current wave 

    float spawnTimer;
    private int enemiesAlive = 0;
    public float waveInterval; // THe interval between each wave. we will be using a  ine. 
    public int maxEnemiesAllowed;
    public bool maxEnemiesReached = false; // a flag indicating if max number of enemies reached
    void Start()
    {
        player = FindObjectOfType<PlayerStats>().transform;
        CalculateWaveQuota();
    }

    // Update is called once per frame
    void Update()
    {

        // // // if there are more waves to spawn and current wave's spawnCount == 0, start coroutine
        if (currentWaveCount < waves.Count && waves[currentWaveCount].spawnCount == 0) //check if next wave has ended and the next wave we should start
        {
            StartCoroutine(BeginNextWave());
        }


        spawnTimer += Time.deltaTime;
        SpawnEnemies();


    }


    //responsible for checking if there is a next wave

    //wait for wave interval to pass before incrementing current wave count
    IEnumerator BeginNextWave()
    {
        //Wave for 'waveInterval" seconds before starting the next wave
        yield return new WaitForSeconds(waveInterval);

        //if there a more waves to start after the current wave, move on to the next wave
        if (currentWaveCount < waves.Count - 1)
        {
            currentWaveCount++;
            CalculateWaveQuota();
        }
    }
    void CalculateWaveQuota()
    {
        int currentWaveQuota = 0;
        foreach (var enemyGroup in waves[this.currentWaveCount].enemyGroups)
        {
            currentWaveQuota += enemyGroup.enemyCount;
        }

        waves[this.currentWaveCount].waveQuota = currentWaveQuota;
        Debug.LogWarning(currentWaveQuota);
    }
    /// <summary>
    /// this method stops spawning enemies if amount of enemies on map is maximum
    /// method will only spawn enemies in a particular wave until it is time for next wave's enemies to be spawned
    /// </summary>
    void SpawnEnemies()
    {
        if (spawnTimer >= waves[currentWaveCount].spawnInterval)
        {
            //1) off cooldown
            //Check if the minimum number of enemies in the wave have been spawned
            if (waves[currentWaveCount].spawnCount < waves[currentWaveCount].waveQuota && !maxEnemiesReached)
            {
                //2) check to see if all enemies have been spawned
                //Spawn each type of enemy until the quota is filled for each enemy group
                foreach (var enemyGroup in waves[currentWaveCount].enemyGroups)
                {
                    // Debug.Log(enemyGroup);
                    //Limit the number of enemies that can be spawned at once
                    if (enemiesAlive >= maxEnemiesAllowed)
                    {
                        maxEnemiesReached = true;
                        return;
                    }
                    //check if the min number of enemies of this type has been spawned
                    if (enemyGroup.spawnCount < enemyGroup.enemyCount)
                    {
                        Vector2 spawnPosition = new Vector2(transform.position.x + Random.Range(-10f, 10f), player.transform.position.y + Random.Range(-10f, 10f));
                        Instantiate(enemyGroup.enemyPrefab, spawnPosition, Quaternion.identity);
                        ++enemyGroup.spawnCount;
                        ++waves[currentWaveCount].spawnCount;
                        ++enemiesAlive;
                    }
                }
            }
        }

        //reset the maxENemiesReahed flag if the number of enemies aivehas dropped below the maximum ni=umber of enemies
        if (enemiesAlive < maxEnemiesAllowed)
        {
            maxEnemiesReached = false;
        }
    }

    public void OnEnemyKilled()
    {
        //Decrement the number of alive enemies
        enemiesAlive--;
    }
}
