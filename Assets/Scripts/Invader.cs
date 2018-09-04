using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : Hazard{

    private float movementRadius;
    private float deathAnimTime;
    private bool rotar;

    // Use this for initialization
    void Start () {

        spinTime = 4;
	}
	
	// Update is called once per frame
	void Update () {
		
        if (rotar)
        {
            deathAnimTime -= Time.deltaTime;
            transform.Rotate(0, 0, 10);
        }

        if(deathAnimTime <= 0)
        {
            rotar = false;
            OnHazardDestroyed();
        }
	}

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() != null || collision.gameObject.GetComponent<APBullet>() != null)
        {
            //TODO: Make this to reduce damage using Bullet.damage attribute
            resistance -= 1;

            if (resistance == 0)
            {
                rotar = true;
            }
        }
        else if (collision.gameObject.GetComponent<Shelter>() != null)
        {
            resistance -= 1;
            collision.gameObject.GetComponent<Shelter>().Damage(1);
            if (resistance == 0)
            {
                rotar = true;
            }
        }
    }

    protected override void OnHazardDestroyed()
    {
        Destroy(gameObject);
    }
}
