using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnHit : MonoBehaviour {

	Rigidbody2D rigidbody;
	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
	}
	
	public float mass = 3.0f;
	void OnCollisionEnter2D(Collision2D collision)
    {
		Destroy(this);
		
        rigidbody.isKinematic = false;
		rigidbody.mass = mass;
    }
}
