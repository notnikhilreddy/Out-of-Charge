using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float playerSpeed, jumpForce;
    private LayerMask platformLayer, bouncerLayer;

    private Rigidbody2D rb;
    private bool isGrounded, isBouncing;
    private EdgeCollider2D ec;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ec = GetComponent<EdgeCollider2D>();
        platformLayer = 1 << LayerMask.NameToLayer("Platform");
        bouncerLayer = 1 << LayerMask.NameToLayer("Bouncer");
    }

    // Update is called once per frame
    void FixedUpdate() {
        isGrounded = ec.IsTouchingLayers(platformLayer);
        isBouncing = ec.IsTouchingLayers(bouncerLayer);
        if(Input.GetAxis("Horizontal") != 0) {
            rb.velocity = new Vector2(playerSpeed * Input.GetAxis("Horizontal"), rb.velocity.y);
        }
        if(Input.GetAxis("Vertical") > 0) {
        	if (isGrounded) {
	            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
	        }
        }
        if(Input.GetAxis("Vertical") < 0) {
        	transform.localScale = new Vector3(1, 0.5f ,1);
        } else {
        	transform.localScale = new Vector3(1, 1 ,1);
        }
        if(isBouncing) {
        	rb.velocity = new Vector2(rb.velocity.x, jumpForce*1.25f);
        }
    }
}
