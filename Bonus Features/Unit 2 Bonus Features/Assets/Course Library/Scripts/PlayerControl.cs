using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 10.0f;
    private float horizontalInput;
    private float width;
    private float height;
    public float Width
    {
        get 
        {
            return height; 
        }
        set
        {
            height = value;
        }
    }
    public float offset = 5.0f;

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer renderer = GameObject.FindWithTag("Ground").GetComponent<MeshRenderer>();
        width = renderer.bounds.size.x / 2;
        height = renderer.bounds.size.z / 2;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        if (transform.position.x >= width - offset || transform.position.x <= offset - width)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed * horizontalInput);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
