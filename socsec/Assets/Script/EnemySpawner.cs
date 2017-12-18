using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class EnemySpawner: MonoBehaviour
{
    public GameObject[] SpawnPoints;
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
        
    }
}