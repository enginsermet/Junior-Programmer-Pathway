using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class RoadControl : MonoBehaviour
{
    [SerializeField]
    public GameObject skyDome;
    [SerializeField]
    public GameObject skyBox;
    private new MeshRenderer renderer;
    public Vector3 roadSize;
    public float roadHeight;
    private float roadPos;
    private float skyDomePos;
    private float skyBoxPos;


    // Start is called before the first frame update
    void Start()
    {
        renderer = GameObject.Find("Road").GetComponent<MeshRenderer>();
        roadSize = renderer.bounds.size;
        roadHeight = renderer.bounds.size.z;
        roadPos = transform.position.z;
        skyDomePos = skyDome.transform.position.z;
        skyBoxPos = skyBox.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z + roadHeight / 2 < Camera.main.transform.position.z )
        {
            MoveRoad();
        }

    }

    private void MoveRoad()
    {
        skyDomePos += roadHeight * 2;
        skyBoxPos += roadHeight * 2;
        roadPos += (roadHeight * 2);

        Vector3 newPosition = new Vector3(0, 0, roadPos);
        Vector3 newDomePosition = new Vector3(0, 0, skyDomePos);
        Vector3 newBoxPosition = new Vector3(skyBox.transform.position.x, skyBox.transform.position.y, skyBoxPos);
        transform.position = newPosition;
        skyDome.transform.position = newDomePosition;
        skyBox.transform.position = newBoxPosition;

    }
}
