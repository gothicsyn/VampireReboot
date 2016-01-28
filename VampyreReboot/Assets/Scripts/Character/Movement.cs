using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class Movement : MonoBehaviour {
	Animator anim;
	bool isWalking = false;
	const float WALK_SPEED = .5f;

	void Awake()
	{
		anim = GetComponent<Animator>();
	}

	void Update ()
	{
		// Commands for Turning, Jumping, Moving and Walking
		Walking();
		Turning();
		Move();
	}

	// Turning
	void Turning()
	{
		anim.SetFloat("Turn", Input.GetAxis("Horizontal"));
	}

	// Toggles the Walking State On or Off
	void Walking()
	{
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			isWalking = !isWalking;
			anim.SetBool ("Walk", isWalking);
		}
	}

	// Allows For 360 Movement Alongside Mechanims Root Motion Controller
	void Move()
	{
		if(anim.GetBool("Walk"))
		{
			anim.SetFloat("MoveZ", Mathf.Clamp(Input.GetAxis("MoveZ"), -WALK_SPEED, WALK_SPEED));
			anim.SetFloat("MoveX", Mathf.Clamp(Input.GetAxis("MoveX"), -WALK_SPEED, WALK_SPEED));
		}
		else
		{
			anim.SetFloat("MoveZ", Input.GetAxis("MoveZ"));
			anim.SetFloat("MoveX", Input.GetAxis("MoveX"));
		}
	}
}