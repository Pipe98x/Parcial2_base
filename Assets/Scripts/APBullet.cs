using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APBullet : Bullet {

	// Use this for initialization
	void Start () {

        myCollider = GetComponent<Collider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();

        myRigidbody.AddForce(transform.up * force, ForceMode2D.Impulse);

        Invoke("AutoDestroy", autoDestroyTime);
        force = 5f;
	}
	
}
