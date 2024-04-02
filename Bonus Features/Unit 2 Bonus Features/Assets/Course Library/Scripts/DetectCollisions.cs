using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private GameManager gameManager;
    private Animal animal;
    private Food food;
    private HungerBar hungerBar;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Animal"))
        {
            animal = other.gameObject.GetComponent<Animal>();
            food = gameObject.GetComponent<Food>();
            hungerBar = other.GetComponentInChildren<HungerBar>();

            Destroy(gameObject);
            hungerBar.UpdateHungerBar(food.FoodPoint);

            if (animal.isActiveAndEnabled)
            {
                animal.HungerPoint--;
            }

            if (animal.HungerPoint == 0)
            {
                Destroy(other.gameObject, 0.1f);
                int scoreToAdd = animal.ScorePoint;
                gameManager.UpdateScore(scoreToAdd);
            }
        }

    }
}
