using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffect : MonoBehaviour {
    internal GameObject ParticleEffect;
    public Vector3 Offset;

	// Use this for initialization
	void Start () {
		
	}

    private void OnEnable()
    {
        Ray ray = new Ray(new Vector3(transform.position.x + Offset.x, transform.position.y + Offset.y, -30), new Vector3(0, 0, 1));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, 1 << 8))
        {
            GameObject.Instantiate(ParticleEffect, hit.point, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnDrawGizmos()
    {
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position + Offset + Vector3.back, transform.position + Offset + Vector3.forward);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + Offset + Vector3.left, transform.position + Offset + Vector3.right);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position + Offset + Vector3.down, transform.position + Offset + Vector3.up);
    }
}
