using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    public static bool runAgents = false;

	// Use this for initialization
	void Start () {
		
	}

    void Update() {
        CheckMouseClick();
        UpdateMovable();
    }

    public void RunAgents() {
        runAgents = true;
    }

    Movable objectMoving;
    Vector3 offset;

    // If mouse c
    void CheckMouseClick() {
        if (Input.GetMouseButtonDown(0)) {
            
            if (objectMoving == null) {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

                if (hit.collider != null) {
                    Movable movable = hit.collider.GetComponent<Movable>() ;
                    if (movable != null) {
                        objectMoving = movable;

                        Rigidbody2D rigidbody = objectMoving.GetComponent<Rigidbody2D>();

                        if (rigidbody != null) {
                            objectMoving.GetComponent<Rigidbody2D>().isKinematic = true;
                            objectMoving.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                            objectMoving.GetComponent<Rigidbody2D>().angularVelocity = 0;
                        }
                        objectMoving.GetComponent<Collider2D>().enabled = false;
                        offset = movable.transform.position - mousePos;
                    }
                }
            } else {

                Rigidbody2D rigidbody = objectMoving.GetComponent<Rigidbody2D>();

                if (rigidbody != null) {
                    objectMoving.GetComponent<Rigidbody2D>().isKinematic = false;
                }
                objectMoving.GetComponent<Collider2D>().enabled = true;
                objectMoving = null;
            }
        }
    }

    void UpdateMovable() {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (objectMoving != null) {

            Vector3 newPos = mousePos + offset;
            newPos.z = 0;
            objectMoving.transform.position = newPos;
        }
    }
	
}
