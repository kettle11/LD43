using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	public LevelScript[] levels;

	public static LevelScript currentLevel;

	public static LevelManager instance;

	public static List<GameObject> thingsToUnspawn = new List<GameObject>();

	public static int currentDead;
	void Awake () {
		instance = this;

		UnityEngine.Object[] levelScripts = Resources.FindObjectsOfTypeAll(typeof(LevelScript));
		
		levels = new LevelScript[levelScripts.Length];

		int i = 0;
		foreach (LevelScript level in levelScripts) {
			levels[i] = level;
			i++;
		}
	}

	public static void AssignLevel(LevelScript level) {
		currentLevel = level;
		level.gameObject.SetActive(true);
		PlayerControls.goalScoreTextStatic.text = "" + currentLevel.targetSavedBlueberries;
		currentScore = 0;
	}

	void NextLevel() {

		foreach(GameObject go in thingsToUnspawn) {
			Destroy(go);
		}
		
		int index = currentLevel.index;

		currentLevel.Unload();
		currentLevel.gameObject.SetActive(false);

		foreach(LevelScript level in levels) {
			if (level.index == index + 1) {
				level.gameObject.SetActive(true);
			}
		}

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
	
	public Text currentDeadText;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.N)) {
			NextLevel();
		}


	}

	public GameObject deadIcon;

	public static void IncrementDead() {

		LevelManager.currentDead++;

		if (currentDead > 0) {
			instance.deadIcon.SetActive(true);
		}

		instance.currentDeadText.text = currentDead.ToString();
	}
}
