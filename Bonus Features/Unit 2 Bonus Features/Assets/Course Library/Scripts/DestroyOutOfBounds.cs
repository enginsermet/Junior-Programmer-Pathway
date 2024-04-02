using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class DestroyOutOfBounds : MonoBehaviour
{
    private PlayerControl playerControl;
    private Vector3 objectPos;

    private void Start()
    {
        playerControl = FindObjectOfType<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        objectPos = transform.position;

        if (objectPos.z < -ScreenCalculator.instance.Height - ScreenCalculator.instance.OffSet || objectPos.z > ScreenCalculator.instance.Height + ScreenCalculator.instance.OffSet)
        {
            Destroy(gameObject);
        }
        else if (objectPos.x > ScreenCalculator.instance.Width + ScreenCalculator.instance.OffSet || objectPos.x < -ScreenCalculator.instance.Width - ScreenCalculator.instance.OffSet)
        {
            Destroy(gameObject);
        }

    }

}
