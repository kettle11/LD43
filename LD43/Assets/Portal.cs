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
	
	int currentSaved = 0;
	int currentTarget = 50;

	void Reset() {
		currentSaved = 0;
	}
	
	void OnCollisionEnter2D(Collision2D collision)
    {
		collision.gameObject.SetActive(false);
		portaled.Add(collision.rigidbody);

		if (collision.gameObject.tag == "Scorable") {
			LevelManager.IncrementScore();
		}
    }
}
