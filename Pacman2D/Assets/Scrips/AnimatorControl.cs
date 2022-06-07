
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class AnimatorControl : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] bool isGhost;

    Animator animator;
    Vector2 lastDirection;
    Rigidbody2D body;
    Vector2 direction;

    public Vector2 Direction
    {
        get { return direction;  }
        set { direction = value; }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();

        body.gravityScale = 0;
    }

    void Update()
    {
        if (!isGhost)
        {
            direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }


        if (body.velocity.magnitude > 0)
        {
            lastDirection = body.velocity.normalized;
        }
        animator.SetFloat("Horizontal", lastDirection.x);
        animator.SetFloat("Vertical", lastDirection.y);
        animator.SetFloat("Speed", Vector2.ClampMagnitude(body.velocity, 1).magnitude); // direction.magnitude / maxVelocity 

    }

    private void FixedUpdate()
    {
        body.velocity = direction * speed;
        Debug.Log(direction);
    }

}
