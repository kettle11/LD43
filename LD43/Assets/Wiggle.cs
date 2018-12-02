using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiggle : MonoBehaviour {

	Rigidbody2D rigidbody;
	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
	}
	
	public float frequency = 2.0f;

	public float strength = 10.0f;
	 float timer = 0;
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;

		if (timer < 0) {
			rigidbody.AddForce(Random.insideUnitCircle * Random.value * strength);
			timer = frequency;
		}
	}
}
