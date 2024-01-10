using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{

    public Button playBtn = default;
    public Button singleBtn = default;
    public Button multiBtn = default;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        playBtn.gameObject.SetActive(false);
        singleBtn.gameObject.SetActive(true);
        multiBtn.gameObject.SetActive(true);
    }

    public void Singleplayer()
    {
        SceneManager.LoadScene("Singleplayer");
    }

    public void Multiplayer()
    {
        SceneManager.LoadScene("Multiplayer");
    }
}
