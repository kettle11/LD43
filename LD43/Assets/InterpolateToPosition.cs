using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterpolateToPosition : MonoBehaviour {

	public AnimationCurve curve;
	
	public Vector3 targetPosition;
	public Vector3 startPosition;

	public float duration;

	float currentTimeElapsed = 0;

	// Use this for initialization
	void Start () {
		
	}

	
	public void StartInterpolationTo(Vector3 position) {
		startPosition = this.transform.position;
		this.GetComponent<Collider2D>().enabled = false;
		targetPosition = position;
	}

	// Update is called once per frame
	void Update () {
		this.transform.position = Vector3.Lerp(startPosition, targetPosition, curve.Evaluate(currentTimeElapsed / duration));

		currentTimeElapsed += Time.deltaTime;

		if (currentTimeElapsed > duration) {
			this.GetComponent<Collider2D>().enabled = true;

			this.transform.position = targetPosition;
			Destroy(this); // Remove this component.
		}
	}
}
