using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpType { None, Pushback, HomingRockets, Smash }

public class PowerUp : MonoBehaviour
{

    [SerializeField] private Material powerupMaterial;

    [SerializeField] private PowerUpType powerUpType;

    public PowerUpType PowerUpType
    {
        get
        {
            return powerUpType;
        }
        set
        {
            powerUpType = value;
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

    internal Material GetPowerupMaterial()
    {
        return powerupMaterial;
    }
}
