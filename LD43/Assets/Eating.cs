using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eating : MonoBehaviour {

	public AudioSource source;
	public AudioClip[] clips;
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
		holdMouthOpen = .2f;
	}

	public void Eat(GameObject gameObject) {
		if (!eatingEnabled) return;

		spriteRenderer.sprite = mouthClosed;
		mouthClosedTimer = mouthClosedTime;

		if (gameObject.tag == "Scorable") {
			blueberryCount++;
			LevelManager.IncrementDead();

			if (blueberryCount >= blueberryGoal) {
				CreateBumper();
				blueberryCount = 0;
			}
		}

		source.PlayOneShot(clips[(int)Random.Range(0, clips.Length)]);

		Destroy(gameObject);
	}

	public GameObject bumper;

	float holdMouthOpen = 0;

	public Transform targetBumperPosition;

	static bool firstTime = true;

	void CreateBumper() {
		holdMouthOpen += 1.0f;
		GameObject newBumper = Instantiate(bumper);
		newBumper.transform.position = this.transform.position;
		newBumper.GetComponent<InterpolateToPosition>().StartInterpolationTo(targetBumperPosition.position);
		
		LevelManager.thingsToUnspawn.Add(newBumper);

		if (firstTime) {
				ScrollingText.SetText(new[]{"Tell no one..."});
				firstTime = false;
		}
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
