using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entitys_Movement : MonoBehaviour
{
    [SerializeField] float speed = 1;
    Vector2 direction;
    Rigidbody2D body;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        body.velocity = direction * speed;
    }

    public void moveToDirection(Vector2 direction)
    {
        this.direction = direction;
    }
}
