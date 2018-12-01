using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    public static bool runAgents = false;

	// Use this for initialization
	void Start () {
		
	}

    void Update() {

        UpdateMovable();
        UpdateRotatable();

        if (!skipCheckThisFrame) CheckMouseClick();
        skipCheckThisFrame = false;
    }

    public void RunAgents() {
        runAgents = true;
    }

    Movable objectMoving;
    Vector3 offset;

    RotateHandle objectRotating;
    bool skipCheckThisFrame = false;

    // If mouse c
    void CheckMouseClick() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            CheckForRotationHandle(hit, mousePos);

            if (objectRotating == null) {
                CheckForMovable(hit, mousePos);
            }
        }
    }

    void CheckForRotationHandle(RaycastHit2D hit, Vector3 mousePos) {
        if (hit.collider != null) {
            RotateHandle handle = hit.collider.GetComponent<RotateHandle>();

            if (handle != null) {
                objectRotating = handle;
                objectRotating.InitPosition();
            }
        }
    }

    void UpdateRotatable() {
        
        if (objectRotating != null) {

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            objectRotating.SetPositionAndRotate(mousePos);

            if (Input.GetMouseButtonUp(0)) {
                objectRotating = null; 
                skipCheckThisFrame = true;
            }
        }
    }

    void CheckForMovable(RaycastHit2D hit, Vector3 mousePos) {

            if (objectMoving == null) {


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
                       // objectMoving.GetComponent<Collider2D>().enabled = false;
                        offset = movable.transform.position - mousePos;
                    }
                }
            }
    }
    void UpdateMovable() {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (objectMoving != null) {

            Vector3 newPos = mousePos + offset;
            newPos.z = 0;
            objectMoving.transform.position = newPos;


            if (Input.GetMouseButtonUp(0))
            {
                Rigidbody2D rigidbody = objectMoving.GetComponent<Rigidbody2D>();

                if (rigidbody != null) {
                    objectMoving.GetComponent<Rigidbody2D>().isKinematic = false;
                }
                //objectMoving.GetComponent<Collider2D>().enabled = true;
                objectMoving = null;
            }
        }

    }
	
}