using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletePlayerController : MonoBehaviour {

    public float speed;             //Floating point variable to store the player's movement speed.
	public float frictionSpeed;

    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
	private Vector2 specificMovement;

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D> ();
    }

	//FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
	void FixedUpdate()
	{
		//Store the current horizontal input in the float moveHorizontal.
		float moveHorizontal = Input.GetAxis("Horizontal");

		//Store the current vertical input in the float moveVertical.
		float moveVertical = Input.GetAxis("Vertical");

		//Use the two store floats to create a new Vector2 variable movement.
		Vector2 movement = new Vector2(moveHorizontal, moveVertical);

		//Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
		rb2d.AddForce(movement * speed);

		if (moveHorizontal == 0 && moveVertical == 0)
		{
			rb2d.AddForce(-rb2d.velocity*frictionSpeed);
		}

		specificMovement += movement * speed;

		Vector2 moveDirection = rb2d.velocity;
		if (moveDirection != Vector2.zero)
		{
			float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
			rb2d.transform.rotation = Quaternion.AngleAxis(angle-90f, Vector3.forward);
		}

	}
}
