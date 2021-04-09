using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaveSpawner : MonoBehaviour
{




    [System.Serializable]
    public class Wave
    {

        public Enemy[] enemies;
        public int count;
        public float timeBetweenSpawn;

    }
    public Wave[] waves;
    public Transform[] spawnPoints;
    public float timeBetweenWaves;
    private Wave currentWave;
    private int currentWaveIndex = 0;
    private Transform player;
    private bool finishedSpanwing = false;



    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(StartNextWave(currentWaveIndex));

    }




    IEnumerator StartNextWave(int index)
    {

        yield return new WaitForSeconds(timeBetweenWaves);
        StartCoroutine(SpawnWave(index));
    }
    IEnumerator SpawnWave(int index)
    {
        currentWave = waves[index];
        for (int i = 0; i < currentWave.count; i++)
        {
            if (player == null)
            {
                yield break;
            }
            Enemy randoEnemy = currentWave.enemies[Random.Range(0, currentWave.enemies.Length)];
            Transform randomSpot = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randoEnemy, randomSpot.position, randomSpot.rotation);
            yield return new WaitForSeconds(currentWave.timeBetweenSpawn);


            if (i == currentWave.count - 1)
            {

                finishedSpanwing = true;


            }
            else
            {
                finishedSpanwing = false;
            }
        }
    }

    private void Update()
    {
        if (finishedSpanwing == true && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            finishedSpanwing = false;
            if (currentWaveIndex + 1 < waves.Length)
            {
                currentWaveIndex++;
                StartCoroutine(StartNextWave(currentWaveIndex));
            }
            else
            {
                Debug.Log("Game Done!");
            }
        }
    }

}