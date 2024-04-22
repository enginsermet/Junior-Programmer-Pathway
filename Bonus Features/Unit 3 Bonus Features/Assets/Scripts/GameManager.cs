using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameStarted = false;
    public bool gameOver = false;

    public Transform endMarker;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;


    [SerializeField] private TMP_Text scoreText;
    private int score = 0;
    private float startDelay = 1;
    private float repeatRate = 1;

    private GameObject player;


    private PlayerControl playerControl;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        playerControl = GameObject.Find("Player").GetComponent<PlayerControl>();

        StartCoroutine(MovePlayer());

        InvokeRepeating(nameof(UpdateScore), startDelay, repeatRate);

    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position == endMarker.position)
        {
            playerControl.playerAnim.SetTrigger("Game_Start_trig");
            gameStarted = true;
        }

        if (gameOver)
        {
            CancelInvoke();
        }
    }

    public void UpdateScore()
    {
        if (gameStarted && playerControl.boostActive)
        {
            score = score + 2;
        }
        else if (gameStarted && !playerControl.boostActive)
        {
            score++;
        }
        scoreText.text = "Score: " + score;
    }

    IEnumerator MovePlayer()
    {
        Vector3 startPos = player.transform.position;
        Vector3 endPos = endMarker.position;

        startTime = Time.time;
        journeyLength = Vector3.Distance(startPos, endPos);

        float distCovered = (Time.time - startTime) * speed;

        float fractionOfJourney = distCovered / journeyLength;

        while(fractionOfJourney < 1)
        {

            distCovered = (Time.time - startTime) * speed;
            fractionOfJourney = distCovered / journeyLength;
            playerControl.transform.position = Vector3.Lerp(startPos, endPos, fractionOfJourney);
            yield return null;
        }
        

    }
}
