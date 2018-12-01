using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

	static List<Rigidbody2D> portaled = new List<Rigidbody2D>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision)
    {
		collision.gameObject.SetActive(false);
		portaled.Add(collision.rigidbody);
    }
}
