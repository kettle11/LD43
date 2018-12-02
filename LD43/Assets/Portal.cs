using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	int currentSaved = 0;
	int currentTarget = 50;

	void Reset() {
		currentSaved = 0;
	}
	
	void OnCollisionEnter2D(Collision2D collision)
    {


		if (collision.gameObject.tag == "Scorable") {
			
			Destroy(collision.gameObject);

			var movable = collision.gameObject.GetComponent<Movable>();
			
			bool valid = movable == null || !movable.invalid;

			if (valid)	{
				LevelManager.IncrementScore();
			} else {
				ScrollingText.InsertText(new[]{"Hey!", "NO CHEATING!"});
			}

		}
    }
}
