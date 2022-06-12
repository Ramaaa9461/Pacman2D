
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class AnimatorControl : MonoBehaviour
{
    Vector2 lastDirection;
    Animator animator;
    Rigidbody2D body;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();

        body.gravityScale = 0;
    }

    void Update()
    {

        if (body.velocity.magnitude > 0)
        {
            lastDirection = body.velocity.normalized;
        }

        animator.SetFloat("Horizontal", lastDirection.x);
        animator.SetFloat("Vertical", lastDirection.y);
        animator.SetFloat("Speed", Vector2.ClampMagnitude(body.velocity, 1).magnitude); // direction.magnitude / maxVelocity 

    }

    


}
