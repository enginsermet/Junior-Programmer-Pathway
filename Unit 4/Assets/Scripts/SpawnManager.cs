using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private List<GameObject> powerupPrefabs;

    private float spawnRange = 9.0f;
    private int enemyCount;
    private int waveNumber;
    private Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(RandomPowerup(), GenerateSpawnPosition(), RandomPowerup().transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            GameObject powerup = RandomPowerup();
            Instantiate(powerup, GenerateSpawnPosition(), powerup.transform.rotation);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            GameObject enemy = RandomEnemy();
            Instantiate(enemy, GenerateSpawnPosition(), enemy.transform.rotation);
        }
    }

    Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        return spawnPosition = new Vector3(spawnPosX, RandomEnemy().transform.position.y, spawnPosZ);
    }

    GameObject RandomEnemy()
    {
        return enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
    }

    GameObject RandomPowerup()
    {
        return powerupPrefabs[Random.Range(0, powerupPrefabs.Count)];
    }
}
