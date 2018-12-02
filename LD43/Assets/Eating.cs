using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eating : MonoBehaviour {

	public SpriteRenderer spriteRenderer;
	public Sprite defaultSprite;
	
	public Sprite mouthOpen;
	public Sprite mouthClosed;

	public float mouthClosedTime = 1.0f;

	float mouthClosedTimer = -1;

	public int blueberryGoal = 4;
	int blueberryCount = 0;

	public bool eatingEnabled = true;

	// Use this for initialization
	void Start () {
		
	}
	
	public void OpenMouth() {

		if (!eatingEnabled) return;
		spriteRenderer.sprite = mouthOpen;
	}

	public void Eat(GameObject gameObject) {
		if (!eatingEnabled) return;

		spriteRenderer.sprite = mouthClosed;
		mouthClosedTimer = mouthClosedTime;

		if (gameObject.tag == "Scorable") {
			blueberryCount++;

			if (blueberryCount >= blueberryGoal) {
				CreateBumper();
				blueberryCount = 0;
			}
		}

		Destroy(gameObject);
	}

	public GameObject bumper;

	float holdMouthOpen = 0;

	public Transform targetBumperPosition;

	void CreateBumper() {
		holdMouthOpen += 1.0f;
		Instantiate(bumper);
		bumper.transform.position = this.transform.position;
		bumper.GetComponent<InterpolateToPosition>().StartInterpolationTo(targetBumperPosition.position);
	}

	// Update is called once per frame
	void Update () {
		if (mouthClosedTimer - Time.deltaTime < 0 && mouthClosedTimer >= 0) {
			spriteRenderer.sprite = defaultSprite;
		}

		if (holdMouthOpen > 0) {
			spriteRenderer.sprite = mouthOpen;
		}

		if (holdMouthOpen > 0 && holdMouthOpen - Time.deltaTime < 0) {
			spriteRenderer.sprite = defaultSprite;
		}

		holdMouthOpen -= Time.deltaTime;

		mouthClosedTimer -= Time.deltaTime;
	}
}
