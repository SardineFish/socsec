using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Weapon {
    public Vector2 Target;

    public float Speed;

    public float ParticleSpeed = 5;

    public float DestinationRange = 0.1f;

    public float HitBack = 1;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update ()
	{
	    var pos = new Vector2(transform.position.x, transform.position.y);
	    var dir = Target - pos;
	    if (dir.magnitude < DestinationRange)
	    {
	        Destroy(gameObject);
	        //GetComponent<ParticleSystem>().Stop();
	        /*var main = GetComponent<ParticleSystem>().main;
	        main.startSpeed = ParticleSpeed - Speed;
	        GetComponent<ParticleSystem>().startSpeed = ParticleSpeed - Speed;*/

            return;
	    }
	    var rotation = Quaternion.FromToRotation(Vector2.right, dir);
	    transform.rotation = rotation;
	    transform.Translate(Vector2.right * Speed * Time.deltaTime, Space.Self);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().HP -= Damage;
            collision.GetComponent<Enemy>().Speed = 0;
             collision.GetComponent<Rigidbody2D>().AddForce(transform.forward*HitBack, ForceMode2D.Impulse);
        }
    }
}
