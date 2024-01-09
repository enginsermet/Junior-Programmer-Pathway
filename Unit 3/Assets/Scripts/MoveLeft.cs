using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed;
    private PlayerControl playerControl;

    // Start is called before the first frame update
    void Start()
    {

        playerControl = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControl.GameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

    }


}
