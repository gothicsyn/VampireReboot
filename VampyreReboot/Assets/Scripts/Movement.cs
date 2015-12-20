using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class Movement : MonoBehaviour {
    Animator anim;
	bool isWalking = false;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update ()
    {
        // Commands for Turning, Jumping, Moving and Walking
		Turning();
		Walking();
        Move();
    }

	void Turning()
	{
		anim.SetFloat("Turn", Input.GetAxis("Horizontal"));
	}

	void Walking()
	{
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			isWalking = !isWalking;
			anim.SetBool ("Walk", isWalking);
		}
	}

    void Move()
    {
        anim.SetFloat("Forward", Input.GetAxis("Vertical"));
    }
}
