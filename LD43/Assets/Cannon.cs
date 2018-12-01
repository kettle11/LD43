using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

	public GameObject firingObject;
	public float firingPower;

	public float spawnOffset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			Fire();
		}
	}

	void Fire() {
		GameObject firedObject = GameObject.Instantiate(firingObject);
		Rigidbody2D rigidbody = firedObject.GetComponent<Rigidbody2D>();
		rigidbody.AddForce(this.transform.up * firingPower, ForceMode2D.Impulse);
		firedObject.transform.position = this.transform.position + this.transform.up * spawnOffset;
	}

}
