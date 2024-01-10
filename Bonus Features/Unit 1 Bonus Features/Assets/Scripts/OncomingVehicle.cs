using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class OncomingVehicle : MonoBehaviour
{
    public GameObject[] vehiclePrefab;

    public GameObject road;

    public Vector3 roadSize;
    private float roadLength;

    private Vector3 offset = new(0, 0, 30.0f);

    Vector3 position;

    List<GameObject> vehicles = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {


        InvokeRepeating(nameof(SpawnVehicles), 1f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject vehicle in vehicles)
        {
            float speed = Random.Range(5.0f, 15.0f);
            vehicle.transform.Translate(Vector3.forward * Time.deltaTime * speed);

        }

    }

    private void LateUpdate()
    {
        road = GameObject.Find("Road");
        roadLength = road.GetComponent<MeshRenderer>().bounds.size.z / 2;
        roadLength += road.transform.position.z;

        foreach (GameObject vehicle in vehicles.ToList())
        {

            if (vehicle.transform.position.z <= 0)
            {
                DestroyVehicle(vehicle);
            }
        }

    }

    void SpawnVehicles()
    {
        float random = Random.Range(0.0f, 1.0f);
        if (random < 0.5f)
        {
            position = new Vector3(Random.Range(-8.0f, -2.5f), 0, roadLength - offset.z);
        }
        else
        {
            position = new Vector3(Random.Range(2.5f, 8.0f), 0, roadLength - offset.z);

        }      
        GameObject vehicle = Instantiate(vehiclePrefab[Random.Range(0, vehiclePrefab.Length)], position, Quaternion.AngleAxis(180, Vector3.up));

        vehicles.Add(vehicle);


    }


    void DestroyVehicle(GameObject vehicle)
    {
        Destroy(vehicle);
        vehicles.Remove(vehicle);
    }
}
