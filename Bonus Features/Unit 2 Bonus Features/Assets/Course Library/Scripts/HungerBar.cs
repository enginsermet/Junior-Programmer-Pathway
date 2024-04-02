using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    [SerializeField] private Slider hungerBar;

    //private Vector3 offset = new Vector3(0, 10, 15);

    // Start is called before the first frame update
    void Start()
    {
        hungerBar.fillRect.gameObject.SetActive(false);
        //hungerBar.transform.position = transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void MaxValue(int hungerPoint)
    {
        hungerBar.maxValue = hungerPoint;
    }

    internal void UpdateHungerBar(int foodPoint)
    {
        hungerBar.fillRect.gameObject.SetActive(true);
        hungerBar.value += foodPoint;
    }
}
