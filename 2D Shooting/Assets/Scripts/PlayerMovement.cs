using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;

	public Joystick joystick;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

	// Update is called once per frame
	void Update () {

		if (joystick.Horizontal >= 0.2f)
		{
			horizontalMove = runSpeed;	
		} else if (joystick.Horizontal <= -0.2f)
		{
			horizontalMove = -runSpeed;
		}
		else
		{
			horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		}

		float verticalMove = joystick.Vertical;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (verticalMove >= 0.5f)
		{
			jump = true;
			animator.SetBool("IsJumping", true);
		}

		if (verticalMove <= -0.5f)
		{
			crouch = true;
		} else
		{
			crouch = false;
		}

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("IsJumping", true);
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}
	}

	public void OnLanding ()
	{
		animator.SetBool("IsJumping", false);
	}

	public void OnCrouching (bool isCrouching)
	{
		animator.SetBool("IsCrouching", isCrouching);
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}
