using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    PlayerControl playerControl;
    // Start is called before the first frame update
    void Start()
    {
        playerControl = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z <= - playerControl.Width - playerControl.offset / 2 )
        {
            Destroy(gameObject);
        }
        else if (transform.position.z >= playerControl.Width + playerControl.offset / 2)
        {
            Destroy(gameObject);

        }

    }

}
