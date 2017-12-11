using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Damage;

    public int HP;

    public int SpawnWeight = 1;

    public float Speed;

    public GameObject Target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    var targetList = GameObject.FindGameObjectsWithTag("City");
	    Target = targetList.OrderBy(target => Vector2.Distance(target.transform.position, transform.position)).FirstOrDefault();
        if (!Target)
            return;

	    transform.Translate(Vector3.Scale(Target.transform.position - transform.position,new Vector3(1,1,0)).normalized * Speed*Time.deltaTime);

	}

    private void OnMouseDown()
    {
        GetComponent<DeathEffect>().enabled = true;
        GameObject.Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "City")
        {
            GetComponent<DeathEffect>().enabled = true;
            GameObject.Destroy(gameObject);
        }
    }
}
