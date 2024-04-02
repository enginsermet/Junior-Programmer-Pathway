using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text livesCountText;

    [SerializeField] private int score;
    [SerializeField] private int lives;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score;
    }

    public void UpdateLives(int value)
    {
        lives += value;

        if (lives <= 0)
        {
            Debug.Log("Game Over");
            lives = 0;
        }

        livesCountText.text = "Lives: " + lives;
    }


}
