using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterpolateToPosition : MonoBehaviour {

	public AnimationCurve curve;
	
	public Vector3 targetPosition;
	public Vector3 startPosition;

	public float duration;

	float currentTimeElapsed = 0;
	bool runInterpolation = false;
	
	// Use this for initialization
	void Start () {
		
	}

	
	public void StartInterpolationTo(Vector3 position) {
		startPosition = this.transform.position;
		this.GetComponent<Collider2D>().enabled = false;
		targetPosition = position;
		runInterpolation = true;
	}

	// Update is called once per frame
	void Update () {

		if (!runInterpolation) return;

		this.transform.position = Vector3.Lerp(startPosition, targetPosition, curve.Evaluate(currentTimeElapsed / duration));

		this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -10);
		
		currentTimeElapsed += Time.deltaTime;

		if (currentTimeElapsed > duration) {
			this.GetComponent<Collider2D>().enabled = true;

			this.transform.position = targetPosition;
			Destroy(this); // Remove this component.
		}
	}
}
