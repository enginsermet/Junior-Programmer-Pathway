using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    private Vector3 spawnPos = new Vector3 (30, 0, 0);
    private int obstacleIndex;
    private float startDelay = 1;
    private float repeatRate = 2;
    private const float leftBound = -5.0f;

    private GameManager gameManager;


    private List<GameObject> obstacles = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        InvokeRepeating(nameof(SpawnObstacle), startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var obstacle in obstacles.ToList())
        {
            if (obstacle.transform.position.x < leftBound)
            {
                Destroy(obstacle);
                obstacles.Remove(obstacle);
            }
        }

        if (gameManager.gameOver)
        {
            CancelInvoke(nameof(SpawnObstacle));
        }
    }

    private void SpawnObstacle()
    {
        if (gameManager.gameStarted)
        {
            obstacleIndex = Random.Range(0, obstaclePrefab.Length);
            obstacles.Add(Instantiate(obstaclePrefab[obstacleIndex], spawnPos, obstaclePrefab[obstacleIndex].transform.rotation));
        }
            
    }
}
