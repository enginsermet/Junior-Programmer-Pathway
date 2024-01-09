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
    private PlayerControl playerControl;


    private List<GameObject> obstacles = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        playerControl = GameObject.Find("Player").GetComponent<PlayerControl>();

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

    }

    private void SpawnObstacle()
    {
        if (!playerControl.GameOver)
        {
            obstacleIndex = Random.Range(0, obstaclePrefab.Length);
            obstacles.Add(Instantiate(obstaclePrefab[obstacleIndex], spawnPos, obstaclePrefab[obstacleIndex].transform.rotation));
        }
        else
        {
            CancelInvoke(nameof(SpawnObstacle));
        }

    }
}
