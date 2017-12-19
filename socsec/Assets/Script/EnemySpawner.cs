using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class EnemySpawner: MonoBehaviour
{
    public GameObject[] SpawnPoints;
    public float SpawnRadius = 1;
    public float SpawnDuration = 1;
    public bool RandomSpawn = false;
    public float RandomRange = 0;
    public GameObject[] SpawnableEnemies;
    public int[] SpawnWeight;

    float nextSpawnTime = 0;
    private void Start()
    {
        
    }

    private void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            if (RandomSpawn)
                nextSpawnTime += SpawnDuration + UnityEngine.Random.Range(-RandomRange, RandomRange);
            else
                nextSpawnTime += SpawnDuration;
            

        }
    }

    private void OnDrawGizmos()
    {
        foreach(var point in SpawnPoints)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(point.transform.position, SpawnRadius);
        }
    }
}