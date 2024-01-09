using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRb;
    private GameObject player;

    [SerializeField] private float speed;

    private Vector3 lookDirection;
    private bool enemyDestroyed;

    public bool EnemyDestroyed
    {
        get
        {
            return enemyDestroyed;
        }
        set
        {
            enemyDestroyed = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {
            lookDirection = (player.transform.position - transform.position).normalized;
        }
        enemyRb.AddForce(lookDirection * speed, ForceMode.Force);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
            enemyDestroyed = true;
        }
    }
}
