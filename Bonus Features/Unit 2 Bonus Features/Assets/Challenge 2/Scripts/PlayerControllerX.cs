using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    private bool onCooldown;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && !onCooldown)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            onCooldown = true;
            Invoke(nameof(DisableCooldown), 1.5f);
        }
    }

    private bool DisableCooldown()
    {
       return onCooldown = false;
    }
}
