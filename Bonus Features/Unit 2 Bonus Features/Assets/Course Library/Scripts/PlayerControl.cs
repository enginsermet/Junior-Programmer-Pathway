using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private float speed;
    private float horizontalInput;
    private float verticalInput;
    [SerializeField] private GameObject projectilePrefab;

    private Vector3 projectileOffSet = new Vector3(0, 0.5f, 0);
    private Vector3 initialPos;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); ;
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {


        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        if (transform.position.x >= ScreenCalculator.instance.Width - ScreenCalculator.instance.OffSet || transform.position.x <= ScreenCalculator.instance.OffSet - ScreenCalculator.instance.Width)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed * horizontalInput);
        }

        if (transform.position.z >= ScreenCalculator.instance.Height - ScreenCalculator.instance.OffSet || transform.position.z <= initialPos.z)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed * verticalInput);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position + projectileOffSet, projectilePrefab.transform.rotation);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Animal"))
        {
            Destroy(col.gameObject);
            gameManager.UpdateLives(-1);
        }        
    }
}
