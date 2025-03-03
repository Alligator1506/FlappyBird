using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private ObjectPooling pipePool;
    [SerializeField] private Transform spawnParent;
    [SerializeField] private float spawnRate = 1.5f;
    [SerializeField] private float heightOffset = 5f;
    [SerializeField] private float spawnXPosition = 10f;

    private float spawnTimer = 0f;

    void Start()
    {
        SpawnPipe();
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnRate)
        {
            SpawnPipe();
            spawnTimer = 0f;
        }
    }

    public void SpawnPipe()
    {
        float randomHeight = Random.Range(-1f, heightOffset);
        Vector3 spawnPosition = new Vector3(spawnXPosition, randomHeight, 0);
        
        GameObject pipe = pipePool.GetPooledPipe();
        if (pipe != null)
        {
            pipe.transform.position = spawnPosition;
            if (spawnParent != null)
            {
                pipe.transform.SetParent(spawnParent, false);
            }
            pipe.SetActive(true);
        }
    }
}
