using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour {

	float z;
	// Use this for initialization
	void Start () {
		z = transform.position.z;
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x, transform.position.y, -10);
	}

	public float force;

	void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rigidbody = collision.rigidbody;
		
		Vector3 normal = collision.contacts[0].normal;

		rigidbody.velocity *= .8f;
		rigidbody.AddForce(-normal * force, ForceMode2D.Impulse);
		
	//	Debug.Log("Bumped!");
    }
}
