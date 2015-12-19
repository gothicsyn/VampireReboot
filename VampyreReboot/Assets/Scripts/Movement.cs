using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
[RequireComponent(typeof(Animator))]
public class Movement : MonoBehaviour {
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update ()
    {
        // Commands for Turning, Jumping, moving
        Move();
    }

    void Move()
    {
        anim.SetFloat("Forward", Input.GetAxisRaw("Vertical"));
    }
}
