
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorControl : MonoBehaviour
{
    Entitys_Movement entitys_Movement;
    Animator animator;
    Vector2 lastDirection;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        entitys_Movement = GetComponent<Entitys_Movement>();
    }

    void Update()
    {
        if (entitys_Movement.Direction.magnitude > 0)
        {
            lastDirection = entitys_Movement.Direction.normalized;
        }

        animator.SetFloat("Horizontal", lastDirection.x);
        animator.SetFloat("Vertical", lastDirection.y);
        animator.SetFloat("Speed", Vector2.ClampMagnitude(entitys_Movement.Direction, 1).magnitude); // direction.magnitude / maxVelocity 

    }

    public void ChangeColor(bool isAttack)
    {
        animator.SetBool("BlueGhost", isAttack);
    }


}
