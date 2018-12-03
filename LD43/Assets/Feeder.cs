using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feeder : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Rigidbody2D targetRigidBody;
	
	public int numberToFeed = 10;
	
	public AudioSource source;
	public AudioClip[] clips;
 
	int numberFed = 0;
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.GetComponent<Bumper>() != null || other.gameObject.tag == "Scorable") {
			Destroy(other.gameObject);
			numberFed += 1;

			if (numberFed >= numberToFeed) {
				targetRigidBody.isKinematic = false;
			}

			if (other.gameObject.tag == "Scorable") {
				LevelManager.IncrementDead();
			}

			source.PlayOneShot(clips[(int)Random.Range(0, clips.Length)]);
		}
	}
}
