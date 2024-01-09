using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> targets;

    [SerializeField]
    private TextMeshProUGUI scoreText, gameOverText;

    [SerializeField]
    private Button restartBtn;

    [SerializeField]
    private GameObject titleScreen;

    private float spawnRate = 1.0f;

    private int score;

    bool isGameActive;

    public bool GameActive
    {
        get
        {
            return isGameActive;
        }
        set
        {
            this.isGameActive = value;
        }
    }

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
        UpdateScore();
    }

    IEnumerator SpawnTargets()
    {
        while (isGameActive)
        {
            GameObject target = targets[Random.Range(0, targets.Count)];
            Instantiate(target);
            yield return new WaitForSeconds(spawnRate);
        }
    }

    internal void StartGame(int difficulty)
    {
        titleScreen.SetActive(false);
        isGameActive = true;
        spawnRate /= difficulty;
        StartCoroutine(nameof(SpawnTargets));
    }

    internal void UpdateScore()
    {
        scoreText.text = "Score: " + Score;
    }

    internal void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        GameActive = false;
        restartBtn.gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
