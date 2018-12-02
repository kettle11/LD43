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
		UnityEngine.Object[] levelScripts = Resources.FindObjectsOfTypeAll(typeof(LevelScript));
		
		levels = new LevelScript[levelScripts.Length];

		foreach(LevelScript level in levelScripts) {
			level.siblingIndex = level.transform.GetSiblingIndex();
			levels[level.siblingIndex-1] = level;
		}
		
		instance = this;
	}

	public static void AssignLevel(LevelScript level) {
		currentLevel = level;
		instance.levels[currentLevel.siblingIndex-1].gameObject.SetActive(true);
		PlayerControls.goalScoreTextStatic.text = "" + currentLevel.targetSavedBlueberries;
		currentScore = 0;
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
