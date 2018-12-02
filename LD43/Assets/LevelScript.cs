using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour {

	public bool bumpersEnabled = true;

	List<Transform> children = new List<Transform>();

	public int siblingIndex = 0;
	
	public int targetSavedBlueberries;
	
	// Use this for initialization
	void Start () {
		LevelManager.AssignLevel(this);

		foreach (Transform transform1 in transform) {
			children.Add(transform1);
		}

		transform.DetachChildren();

		PlayerControls.EnableDisableBumper(bumpersEnabled);
	}
	
	public void Unload() {
		foreach(Transform gameObject in children) {
			Destroy(gameObject.gameObject);
		}
	}
	
	void CurrentLevel() {

	}

	void NextLevel() {

	}

	// Update is called once per frame
	void Update () {
		
	}
}
