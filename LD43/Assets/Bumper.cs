using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour {

	AudioSource source;
	public AudioClip clip;

	public ParticleSystem particleSystem;
	float z;
	// Use this for initialization
	void Start () {
		z = transform.position.z;
		source = GetComponent<AudioSource>();
		particleSystem = GetComponent<ParticleSystem>();
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

		if (collision.gameObject.tag == "Scorable") {
			source.PlayOneShot(clip);
			particleSystem.Emit(10);
		}
		
	//	Debug.Log("Bumped!");
    }
}
