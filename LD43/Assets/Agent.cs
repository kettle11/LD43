using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour {

    Rigidbody2D rigidbody;
    Collider2D selfCollider;

    Vector3 groundObjectOffset;
    
	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
        selfCollider = GetComponent<Collider2D>();
        
        groundObject.transform.SetParent(null);

        groundObjectOffset = this.transform.position - groundObject.transform.position;
	}

    void Update() {
        RunAI();
        
        this.transform.position = groundObject.transform.position + groundObjectOffset;
    }

    Vector3 groundObjectLastFrame;

    public float radius = .4f;
    public float groundedDistance = .45f;
    
    public Vector2 velocity;

    public bool grounded = false;

    public Rigidbody2D groundObject;

    public Vector3 rayOffset;

    public bool cliffAhead = false;

    public float groundSpeed = 2.0f;

    public bool wallAhead = false;
    public float wallDistance = .5f;

    public float jumpCooldown = .3f;
    public float jumpCount = 0;
    
    public float jumpForce = 3.4f;

    public Vector2 jumpForward;
    void RunAI() {
        
        if (!PlayerControls.runAgents) return;

        groundObject.GetComponent<Collider2D>().enabled = false;
        
        RaycastHit2D raycastDown = Physics2D.CircleCast(transform.position, radius, Vector2.down);

        bool velocityDown = groundObject.velocity.y < .3f;

        grounded = raycastDown.distance < groundedDistance && velocityDown;

        if (grounded && jumpCount < 0) {
            groundObject.AddForce(jumpForward, ForceMode2D.Impulse);
            jumpCount = jumpCooldown;
        }

        jumpCount -= Time.deltaTime;

        groundObject.GetComponent<Collider2D>().enabled = true;

    }


}
