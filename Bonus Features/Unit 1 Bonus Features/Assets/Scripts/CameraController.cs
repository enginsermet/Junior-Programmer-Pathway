using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;

    public Camera hoodCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            if (mainCamera.enabled)
            {
                mainCamera.enabled = false;
                hoodCamera.enabled = true;
            }
            else
            {
                mainCamera.enabled = true;
                hoodCamera.enabled = false;
            }
        }
    }
}
