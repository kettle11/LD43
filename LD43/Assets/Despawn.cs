using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour {

	public float lifespan = 10.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (lifespan < 0) {
			Destroy(this.gameObject);
		} else {
			lifespan -= Time.deltaTime;
		}

		if (this.transform.position.y < -10) {
			Destroy(this.gameObject);
			LevelManager.IncrementDead();
		}
	}
}
