using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private int ballIndex;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;
    private bool gameOver = false;
    public float waitTime;

    private IEnumerator coroutine;

    public bool GameOver 
    {
        get 
        {
            return this.gameOver;
        }
        set {
            gameOver = value; 
        } 
    }

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);

        coroutine = SpawnRandomBall();
        StartCoroutine(coroutine);
    }


    // Spawn random ball at random x position at top of play area
    private IEnumerator SpawnRandomBall()
    {
        while (!gameOver)
        {
            float waitTime = Random.Range(3.0f, 5.0f);
            Debug.Log(waitTime);
            ballIndex = Random.Range(0, ballPrefabs.Length);
            // Generate random ball index and random spawn position
            Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

            // instantiate ball at random spawn location
            Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[0].transform.rotation);

            yield return new WaitForSeconds(waitTime);
        }

    }

}
