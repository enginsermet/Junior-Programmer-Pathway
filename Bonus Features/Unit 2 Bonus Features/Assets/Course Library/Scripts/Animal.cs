using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour
{
    [SerializeField] private int hungerPoint;
    [SerializeField] private int scorePoint;

    private HungerBar hungerBar;

    public int ScorePoint { get { return scorePoint; } set { scorePoint = value; } }
    public int HungerPoint { get { return hungerPoint; } set { hungerPoint = value; } }


    // Start is called before the first frame update
    void Start()
    {
        hungerBar = GetComponentInChildren<HungerBar>();
        hungerBar.MaxValue(hungerPoint);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
