using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHandle : MonoBehaviour {

	Transform parent;
	// Use this for initialization
	void Start () {
		parent = this.transform.parent;
	}
	
}
