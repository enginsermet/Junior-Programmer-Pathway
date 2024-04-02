using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCalculator : MonoBehaviour
{
    public static ScreenCalculator instance;

    private float width;
    private float height;
    private const float offset = 5.0f;

    public float Width
    {
        get
        {
            return width;
        }
        set
        {
            width = value;
        }
    }

    public float Height
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

    public float OffSet { get { return offset; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        MeshRenderer renderer = GameObject.FindWithTag("Ground").GetComponent<MeshRenderer>();
        width = renderer.bounds.size.x / 2;
        height = renderer.bounds.size.z / 2;
    }

    // Start is called before the first frame update
    void Start()
    {

    }


}
