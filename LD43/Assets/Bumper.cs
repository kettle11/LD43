using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public float force;

	void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rigidbody = collision.rigidbody;
		
		Vector3 normal = collision.contacts[0].normal;
		rigidbody.AddForce(-normal * force, ForceMode2D.Impulse);

	//	Debug.Log("Bumped!");
    }
}
