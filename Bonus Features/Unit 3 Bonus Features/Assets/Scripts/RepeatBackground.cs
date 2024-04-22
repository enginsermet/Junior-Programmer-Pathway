using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RepeatBackground : MonoBehaviour
{
    private float width;
    private float newPosition;

    // Start is called before the first frame update
    void Start()
    {
        width = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x + width / 2 <= -10.0f )
        {
            newPosition = transform.position.x + width * 2;
            transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
        }
    }
}
