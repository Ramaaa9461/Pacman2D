using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_Movement : MonoBehaviour
{
    protected Vector2 direction;
    protected Entitys_Movement entitys_movement;
    protected Rigidbody2D body;

    private void Awake()
    {
        entitys_movement = GetComponent<Entitys_Movement>();
        body = GetComponent<Rigidbody2D>();
    }
}
