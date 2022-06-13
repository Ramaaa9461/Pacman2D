using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleAiMovement : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent agent;
    Animator animator;

    Vector2 lastDirection;

    void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);

        if (agent.velocity.magnitude > 0)
        {
            lastDirection = agent.velocity.normalized;
        }

        animator.SetFloat("Horizontal", lastDirection.x);
        animator.SetFloat("Vertical", lastDirection.y);
        animator.SetFloat("Speed", Vector2.ClampMagnitude(agent.velocity, 1).magnitude);
    }
}
