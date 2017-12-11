using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimeObject : MonoBehaviour
{
    public float LifeTime;
	// Use this for initialization
	void Start ()
	{
	    GameObject.Destroy(gameObject, LifeTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
