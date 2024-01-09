using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Rigidbody enemyRb;
    private GameObject focalPoint;

    [Header("Player Movement")]
    private float forwardInput;
    [SerializeField] private float speed = 15.0f;
    [SerializeField] private Vector3 velocity;

    [Header("Power Up")]
    [SerializeField] private GameObject powerUpIndicator;

    [Header("Pushback Power Up")]
    private float powerupBoost = 15.0f;
    private Vector3 awayFromPlayer;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    private void Update()
    {

    }

    // Called every fixed framerate frame.
    void FixedUpdate()
    {
        MovePlayer();
    }

    /* Controls player movement */
    void MovePlayer()
    {
        forwardInput = Input.GetAxisRaw("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed, ForceMode.Force);
        powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            powerUpIndicator.SetActive(true);
            StartCoroutine(nameof(PowerUpCountdownRoutine));
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            enemyRb = col.gameObject.GetComponent<Rigidbody>();
            awayFromPlayer = (col.transform.position - transform.position).normalized;
            enemyRb.AddForce(awayFromPlayer * powerupBoost, ForceMode.Impulse);
        }
    }

    /* Power Up Timer */
    IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        powerUpIndicator.SetActive(false);
    }
}
