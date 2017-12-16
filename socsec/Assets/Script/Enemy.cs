using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int DamageToCity;

    public int HP;

    public int HitDamage;

    public int SpawnWeight = 1;

    public float MaxSpeed = 1;

    public float Speed = 0;

    public float Acceleration = 1;

    public Vector3 MoveDirection;

    public GameObject DeathEffect;
    public GameObject AttackEffect;

    public GameObject Target;

    private DeathEffect deathEffect;
	// Use this for initialization
	void Start ()
	{
	    deathEffect = GetComponent<DeathEffect>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    Speed += Acceleration * Time.deltaTime;
	    if (Speed > MaxSpeed)
	        Speed = MaxSpeed;
	    var targetList = GameObject.FindGameObjectsWithTag("City");
	    Target = targetList.OrderBy(target => Vector2.Distance(target.transform.position, transform.position)).FirstOrDefault();
        if (!Target)
            return;


	    transform.Translate(
	        Vector3.Scale(Target.transform.position - transform.position, new Vector3(1, 1, 0)).normalized * Speed *
	        Time.deltaTime);

        RaycastHit hit;
	    var ray = new Ray(new Vector3(transform.position.x, transform.position.y, -50), new Vector3(0, 0, 1));
	    if (Physics.Raycast(ray, out hit, 100, 1 << 8))
	    {
	        transform.position = new Vector3(transform.position.x, transform.position.y, hit.point.z);
	    }
	    if (HP <= 0)
	    {
	        deathEffect.ParticleEffect = DeathEffect;
	        deathEffect.enabled = true;
	        GameObject.Destroy(gameObject);
	    }
    }

    private void OnMouseDown()
    {
        /*HP -= HitDamage;
        if (HP <= 0)
        {
            deathEffect.ParticleEffect = DeathEffect;
            deathEffect.enabled = true;
            GameObject.Destroy(gameObject);
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "City")
        {
            deathEffect.ParticleEffect = AttackEffect;
            deathEffect.enabled = true;
            GameObject.Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
