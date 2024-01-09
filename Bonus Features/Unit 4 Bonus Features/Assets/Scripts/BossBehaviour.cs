using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject enemyMinionPrefab;
    [SerializeField] private int minionCount = 3;
    [SerializeField] private float time = 1.0f;
    [SerializeField] private float repeatRate = 5.0f;
    private Vector3 minionSpawnPos;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnMinions), time, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        minionSpawnPos = transform.forward * 2;

    }

    private void SpawnMinions()
    {

        for (int i = 0; i < minionCount; i++)
        {
            Instantiate(enemyMinionPrefab, minionSpawnPos, Quaternion.identity);
        }
    }
}
