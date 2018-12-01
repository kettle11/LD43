using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHandle : MonoBehaviour {

	Transform parent;

	Vector3 lastAngle;

	// Use this for initialization
	void Start () {
		parent = this.transform.parent;

		lastAngle = this.transform.position - parent.position;
		lastAngle.Normalize();
	}

	public void InitPosition() {
		lastAngle = this.transform.position - parent.position;
	}

	public void SetPositionAndRotate(Vector3 position) {

		Vector3 newAngle = position - parent.position;
		newAngle.Normalize();

		float angle = Vector2.SignedAngle(lastAngle, newAngle);
		parent.transform.Rotate (Vector3.forward * angle);

		lastAngle = this.transform.position - parent.position;
	}
	
}
