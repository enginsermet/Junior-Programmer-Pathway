using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody targetRb;

    private float maxSpeed = 16.0f;
    private float minSpeed = 12.0f;
    private float speed;
    private float maxTorque = 10.0f;
    private float torqueX, torqueY;
    private float xRange = 4.0f;
    private float ySpawnPos = -2.0f;

    [SerializeField]
    private int pointValue;
    [SerializeField]
    private ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRb = GetComponent<Rigidbody>();
        SpawnTarget();
        MoveTarget();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (gameManager.GameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.Score += pointValue;
            gameManager.UpdateScore();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!other.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }

    void SpawnTarget()
    {
        transform.position = new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    void MoveTarget()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        torqueX = Random.Range(-maxTorque, maxTorque);
        torqueY = Random.Range(-maxTorque, maxTorque);
        targetRb.AddForce(Vector3.up * speed, ForceMode.Impulse);
        targetRb.AddTorque(new Vector3(torqueX, torqueY), ForceMode.Impulse);
    }
}
