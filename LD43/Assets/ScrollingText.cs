using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingText : MonoBehaviour {

	public List<string> texts = new List<string>();

	int currentTextIndex = 0;

	public float textLinger = 2.0f;
	float textLingerCounter = 0;


	float speedPerCharacter = .03f;
	
	string currentStringRemaining;
	string displayString;

	int currentCharacter;
	
	static ScrollingText instance;
	// Use this for initialization
	void Start () {
		LoadTextBox();
		instance = this;
	}
	
	float nextWordTimer;
	string nextWord = "";
	bool reachedEnd = false;

	public Text textBox;

	// Update is called once per frame
	void Update () {
		RunScrollingText();

		if (reachedEnd) {
			if (textLingerCounter < 0 && currentTextIndex != texts.Count - 1) {
				textLingerCounter = 0;
				reachedEnd = false;
				currentStringRemaining = texts[currentTextIndex+1];
				currentTextIndex++;
				displayString = "";
				nextWord = "";
			}

			textLingerCounter -= Time.deltaTime;
		}

	}

	void LoadTextBox() {
		currentStringRemaining = texts[0];
		textBox.text = displayString;
	}	

	public static void InsertText(IEnumerable<string> newTexts) {
		instance.texts.InsertRange(instance.currentTextIndex, newTexts);
		instance.reachedEnd = false;
		instance.nextWord = "";
		instance.displayString = "";
		instance.currentStringRemaining = instance.texts[instance.currentTextIndex];
	}

	public static void SetText(IEnumerable<string> newTexts) {
		instance.texts.Clear();
		instance.texts.AddRange(newTexts);
		instance.reachedEnd = false;
		instance.nextWord = "";
		instance.displayString = "";
		instance.currentStringRemaining = instance.texts[0];
		instance.currentTextIndex = 0;
	}

	public SpriteRenderer targetSpriteChange;
	public Sprite firstSprite;
	public Sprite secondSprite;
	public bool onFirstSprite = false;
	
	void RunScrollingText() {
		if (nextWordTimer < 0 && !reachedEnd) {
			displayString += nextWord + " ";
			var split = currentStringRemaining.Split(new char[]{' '},2);
			
			nextWord = split[0];

			if (split.Length > 1) {
				currentStringRemaining = split[1];
			}
			textBox.text = displayString;
			nextWordTimer = MeasureWord(nextWord);

			if (targetSpriteChange != null && (targetSpriteChange.sprite == firstSprite || targetSpriteChange.sprite == secondSprite)) {
				if (onFirstSprite) {
					targetSpriteChange.sprite = secondSprite;
					onFirstSprite = false;
				} else {
					targetSpriteChange.sprite = firstSprite;
					onFirstSprite = true;
				}
			}

			if (displayString.Length >= texts[currentTextIndex].Length) {
				reachedEnd = true;
				textLingerCounter = textLinger;
			}
		}

		nextWordTimer -= Time.deltaTime;
	}

	float MeasureWord(string word) {
		return word.Length * speedPerCharacter;
	}

	void StepForward() {

	}
}
