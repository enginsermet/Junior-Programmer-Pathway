using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;

    private Vector3 cameraPosition;

    private Vector3 offset = new(0, 6.29f, -10.5f);

    // Start is called before the first frame update
    void Start()
    {

        //Invoke("test", 5);
    }

    void LateUpdate()
    {
        cameraPosition = player.transform.position + offset;
        transform.position = cameraPosition;
    }
    //public void test()
    //{
    //    Camera.main.transform.parent = GameObject.Find("GameObject").transform;

    //    Debug.Log("ol");
    //}
}
