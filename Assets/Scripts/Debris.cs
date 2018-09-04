using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : Hazard{

    private float rotationSpeed;

	// Use this for initialization
	void Start () {

        myCollider = GetComponent<Collider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();

        rotationSpeed = Random.Range(5, 20);
	}
	
	// Update is called once per frame
	void Update () {

        Rotation();
	}

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() != null || collision.gameObject.GetComponent<APBullet>() != null)
        {
            //TODO: Make this to reduce damage using Bullet.damage attribute
            resistance -= 1;

            if (resistance == 0)
            {
                OnHazardDestroyed();
            }
        }
        else if (collision.gameObject.GetComponent<Shelter>() != null)
        {
            resistance -= 1;
            collision.gameObject.GetComponent<Shelter>().Damage(1);
            if (resistance == 0)
            {
                OnHazardDestroyed();
            }
        }
    }

    private void Rotation()
    {
        transform.Rotate(0, 0, rotationSpeed);
    }
}
