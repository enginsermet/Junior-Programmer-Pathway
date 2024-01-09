using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;
using UnityEngine.UIElements.Experimental;

public class Projectile : MonoBehaviour
{
    private Rigidbody projectileRb;
    private GameObject target;

    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;

    [SerializeField] private int damagePoint;

    private Vector3 moveDirection;
    private Vector3 rotateAmount;

    // Start is called before the first frame update
    void Start()
    {
        projectileRb = GetComponent<Rigidbody>();
    }

    // Called every fixed framerate frame.
    void FixedUpdate()
    {
        if (target != null)
        {
            FollowTarget();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().HealthPoint -= damagePoint;
            Destroy(gameObject);
        }
    }

    /* Tracks enemy target */
    internal void TrackTarget(GameObject newTarget)
    {
       target = newTarget;
    }

    /* Projectile follows the enemy target */
    private void FollowTarget()
    {
        moveDirection = (target.transform.position - transform.position).normalized; //Distance between target and projectile
        rotateAmount = Vector3.Cross(moveDirection, transform.forward);
        projectileRb.angularVelocity = -rotateAmount * rotateSpeed;
        projectileRb.velocity = moveDirection * speed;
    }
}
