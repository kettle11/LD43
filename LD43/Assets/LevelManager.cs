using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	public LevelScript[] levels;

	public static LevelScript currentLevel;

	public static LevelManager instance;

	public static List<GameObject> thingsToUnspawn = new List<GameObject>();

	void Awake () {
		UnityEngine.Object[] levelScripts = Resources.FindObjectsOfTypeAll(typeof(LevelScript));
		
		levels = new LevelScript[levelScripts.Length];

		foreach(LevelScript level in levelScripts) {
			level.siblingIndex = level.transform.GetSiblingIndex();
			levels[level.siblingIndex-1] = level;
		}

		instance = this;
	}

	void NextLevel() {

		foreach(GameObject go in thingsToUnspawn) {
			Destroy(go);
		}
		
		currentLevel.Unload();
		currentLevel.gameObject.SetActive(false);

		levels[currentLevel.siblingIndex].gameObject.SetActive(true);

		PlayerControls.goalScoreTextStatic.text = "" + currentLevel.targetSavedBlueberries;
		currentScore = 0;
	}

	static int currentScore;
	public static void IncrementScore() {
		currentScore++;
	
		if (currentScore >= currentLevel.targetSavedBlueberries) {
			LevelManager.NextLevelStatic();
		}

		PlayerControls.scoreTextStatic.text = "" + currentScore;
	}

	public static void NextLevelStatic() {
		instance.NextLevel();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.N)) {
			NextLevel();
		}
	}
}
