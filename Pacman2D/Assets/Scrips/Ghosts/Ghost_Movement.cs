using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_Movement : MonoBehaviour
{
    protected Entitys_Movement entitys_movement;
    protected Vector2 direction;

    private void Awake()
    {
        entitys_movement = GetComponent<Entitys_Movement>();
    }
}
