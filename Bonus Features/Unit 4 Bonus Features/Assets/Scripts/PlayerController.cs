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
    private GameObject projectile, target;
    private PhysicMaterial material;

    [Header("Player Movement")]
    private float forwardInput;
    [SerializeField] private float speed = 15.0f;
    [SerializeField] private Vector3 velocity;

    [Header("Power Up")]
    [SerializeField] private GameObject powerUpIndicator, projectilePrefab;
    [SerializeField] private PowerUpType activePowerUp = PowerUpType.None;

    [Header("Pushback Power Up")]
    private float powerupBoost = 15.0f;
    private Vector3 awayFromPlayer;

    [Header("Homing Power Up")]
    private int projectileTimer = 5;
    private Vector3 projectileOffset = new Vector3(0, 1.0f, 1.5f);

    [Header("Smash Power Up")]
    [SerializeField] private float radius = 15.0f;
    [SerializeField] private float power = 75.0f;
    private bool isOnGround = true;
    private float initialPosY;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        material = GetComponent<SphereCollider>().sharedMaterial;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && activePowerUp == PowerUpType.HomingRockets)
        {
            LaunchRockets();
        }

        if (Input.GetKeyDown(KeyCode.Space) && activePowerUp == PowerUpType.Smash)
        {
            Jump();
        }
    }

    // Called every fixed framerate frame.
    void FixedUpdate()
    {
        MovePlayer();
    }

    /* Controls player movement */
    void MovePlayer()
    {
        // If player is on the ground remove all constraints on player movement
        if (isOnGround)
        {
            playerRb.constraints = RigidbodyConstraints.None;
            material.bounciness = 1;
        }
        else if (!isOnGround)
        {
            playerRb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            material.bounciness = 0;
        }
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
        if (other.gameObject.CompareTag("PowerUp") && activePowerUp == PowerUpType.None)
        {
            activePowerUp = other.gameObject.GetComponent<PowerUp>().PowerUpType;
            powerUpIndicator.GetComponent<MeshRenderer>().material = other.GetComponent<PowerUp>().GetPowerupMaterial();
            Destroy(other.gameObject);
            powerUpIndicator.SetActive(true);
            StartCoroutine(nameof(PowerUpCountdownRoutine));
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            if (activePowerUp == PowerUpType.Pushback)
            {
                enemyRb = col.gameObject.GetComponent<Rigidbody>();
                awayFromPlayer = (col.transform.position - transform.position).normalized;
                enemyRb.AddForce(awayFromPlayer * powerupBoost, ForceMode.Impulse);
            }
        }

        if (col.gameObject.CompareTag("Ground") || col.gameObject.CompareTag("Enemy"))
        {
            if (!isOnGround && activePowerUp == PowerUpType.Smash)
            {
                Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
                foreach (Collider hit in colliders)
                {
                    if (hit.gameObject.CompareTag("Enemy"))
                    {
                        Rigidbody rb = hit.gameObject.GetComponent<Rigidbody>();
                        if (rb != null)
                        {
                            rb.AddExplosionForce(power, transform.position, radius, 0.0f, ForceMode.Impulse);
                        }
                    }
                }
            }
            isOnGround = true;
        }
    }

    /* Launches homing missile projectiles at enemy targets */
    private void LaunchRockets()
    {
        foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            projectile = Instantiate(projectilePrefab, transform.position + projectileOffset, projectilePrefab.transform.rotation);

            if (enemy.gameObject.activeInHierarchy)
            {
                projectile.GetComponent<Projectile>().TrackTarget(enemy);
            }
            Destroy(projectile, projectileTimer);
        }
    }

    /* Moves player in upward direction */
    private void Jump()
    {
        initialPosY = transform.position.y;

        if (isOnGround)
        {
            playerRb.AddForce(Vector3.up * speed, ForceMode.Impulse);
            isOnGround = false;
            Invoke(nameof(SmashAttack), 0.5f);
        }
    }

    /* Moves player in downward direction */
    private void SmashAttack()
    {
        playerRb.velocity = new Vector2(playerRb.velocity.x, -speed * 2);
    }

    /* Power Up Timer */
    IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        activePowerUp = PowerUpType.None;
        powerUpIndicator.SetActive(false);
    }
}
