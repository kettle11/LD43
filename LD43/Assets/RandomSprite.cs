using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprite : MonoBehaviour {

	public List<Sprite> sprites = new List<Sprite>();
	public SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {
		spriteRenderer.sprite = sprites[(int)(Random.value * sprites.Count)];
	}
	
}
