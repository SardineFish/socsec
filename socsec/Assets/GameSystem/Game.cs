using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject[] Enemies;
    public float SpawnSpeed = 1;
    public Camera MainCamera;
    public float SpawnRadius = 10;
    public int count = 0;
    public float time;

	// Use this for initialization
	void Start ()
	{
	    MainCamera = FindObjectOfType<Camera>() as Camera;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    time = Time.time;
	    if (Random.value< SpawnSpeed * Time.deltaTime)
	    {
	        count++;

	        int totalWeight = 0;
	        foreach (var enemy in Enemies)
	        {
	            totalWeight += enemy.GetComponent<Enemy>().SpawnWeight;
	        }
	        foreach (var enemy in Enemies)
	        {
	            if (Random.value <= (float) enemy.GetComponent<Enemy>().SpawnWeight / (float) totalWeight)
	            {
	                var pos = new Vector2(transform.position.x, transform.position.y) +
	                          (Random.insideUnitCircle.normalized * SpawnRadius);
	                Instantiate(enemy, pos, Quaternion.identity);
                    break;
	            }
	            totalWeight -= enemy.GetComponent<Enemy>().SpawnWeight;
	        }
        }
	}
}
