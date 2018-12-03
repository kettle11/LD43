using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueberrySounds : MonoBehaviour {

	AudioSource source;
	public AudioClip clip;
	
	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource>();
	}


	void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Scorable" && collision.gameObject.GetComponent<Bumper>() == null) {
			source.PlayOneShot(clip);
		}
    }

}
