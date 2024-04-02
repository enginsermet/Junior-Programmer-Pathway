using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] animalPrefabs;
    [SerializeField] private GameObject[] spawnLocations;

    private int animalIndex;
    private float startDelay = 1f;
    private float spawnInterval = 1f;

    Vector3 spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnRandomAnimal), startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }


    void SpawnRandomAnimal()
    {
        animalIndex = Random.Range(0, animalPrefabs.Length);
        spawnPos.x = Random.Range(-ScreenCalculator.instance.Width + ScreenCalculator.instance.OffSet, ScreenCalculator.instance.Width - ScreenCalculator.instance.OffSet);
        spawnPos.z = Random.Range(-ScreenCalculator.instance.Height + ScreenCalculator.instance.OffSet, ScreenCalculator.instance.Height);

        GameObject spawnLocation;
        spawnLocation = spawnLocations[Random.Range(0, spawnLocations.Length)];

        if (spawnLocation.transform.position.x < 0)
        {
            spawnPos = new Vector3(spawnLocation.transform.position.x, 0, spawnPos.z);
            Instantiate(animalPrefabs[animalIndex], spawnPos, spawnLocation.transform.rotation);
        }
        else if (spawnLocation.transform.position.x == 0)
        {
            spawnPos = new Vector3(spawnPos.x, 0, spawnLocation.transform.position.z);
            Instantiate(animalPrefabs[animalIndex], spawnPos, spawnLocation.transform.rotation);
        }
        else if (spawnLocation.transform.position.x > 0)
        {
            spawnPos = new Vector3(spawnLocation.transform.position.x, 0, spawnPos.z);
            Instantiate(animalPrefabs[animalIndex], spawnPos, spawnLocation.transform.rotation);
        }
    }
}
