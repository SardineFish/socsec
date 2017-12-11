using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffect : MonoBehaviour {
    public GameObject ParticleEffect;

	// Use this for initialization
	void Start () {
		
	}

    private void OnEnable()
    {
        Ray ray = new Ray(transform.position, new Vector3(0, 0, 1));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, 1 << 8))
        {
            GameObject.Instantiate(ParticleEffect, hit.point, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
