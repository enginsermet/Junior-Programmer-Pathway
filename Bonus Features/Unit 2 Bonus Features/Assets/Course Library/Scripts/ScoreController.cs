using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private int score;
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            this.score = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int scoreToAdd)
    {
        Score += scoreToAdd;
        scoreText.text = "Score: " + Score;
    }
}
