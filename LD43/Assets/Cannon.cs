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
	
	float fireCount = 0;

	public AnimationCurve fireRate;
	public float timeFrame = 2.0f;

	float timeHeld = 0;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space) && fireCount < 0) {
			Fire();
			fireCount = fireRate.Evaluate(timeHeld / timeFrame);
		} 
		
		if (Input.GetKey(KeyCode.Space)) {
			timeHeld += Time.deltaTime;
		}

		if (timeHeld > 0 && !Input.GetKey(KeyCode.Space)) {
			timeHeld = 0;
		}

		fireCount -= Time.deltaTime;
	}

	void Fire() {
		GameObject firedObject = GameObject.Instantiate(firingObject);
		float firedObjectZ = firedObject.transform.position.z;

		Rigidbody2D rigidbody = firedObject.GetComponent<Rigidbody2D>();
		rigidbody.AddForce(this.transform.up * firingPower, ForceMode2D.Impulse);
		firedObject.transform.position = this.transform.position + this.transform.up * spawnOffset;
		firedObject.transform.position = new Vector3(firedObject.transform.position.x, firedObject.transform.position.y, firedObjectZ);
	}
}
