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
    public GameObject[] SpawnableEnemies = new GameObject[0];
    public int[] SpawnWeight = new int[0];

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

            int totalWeight = 0;
            foreach (var weight in SpawnWeight)
            {
                totalWeight += weight;
            }
            for(var i = 0; i < SpawnableEnemies.Length; i++)
            {
                if (UnityEngine.Random.value <= (float)SpawnWeight[i] / (float)totalWeight)
                {
                    var pos = SpawnPoints[UnityEngine.Random.Range(0, SpawnPoints.Length)].transform.position;
                    pos = (pos.ToVector2() + (UnityEngine.Random.insideUnitCircle * SpawnRadius)).ToVector3();
                    Instantiate(SpawnableEnemies[i], pos, Quaternion.identity);
                    break;
                }
                totalWeight -= SpawnWeight[i];
            }
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