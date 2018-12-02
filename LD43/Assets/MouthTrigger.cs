using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthTrigger : MonoBehaviour {

	public Eating mouthControlling;
	public bool openMouth = false;
	public bool closeMouth = false;
	
	void OnTriggerStay2D(Collider2D other) {
		if (openMouth) {
			mouthControlling.OpenMouth();
		} 

		if (closeMouth) {
			mouthControlling.Eat(other.gameObject);
		}
	}
}
