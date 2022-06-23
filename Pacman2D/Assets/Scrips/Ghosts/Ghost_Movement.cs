using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_Movement : MonoBehaviour
{
    private Vector2 initialPosition;
    protected Entitys_Movement entitys_movement;
    protected Vector2 direction;

    public Vector2 InitialPosition
    {
        get { return initialPosition; }
        set { initialPosition = value; }
    }

    private void Awake()
    {
        entitys_movement = GetComponent<Entitys_Movement>();
    }
    private void Start()
    {
        initialPosition = transform.position;
    }
}
